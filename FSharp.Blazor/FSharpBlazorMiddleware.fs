namespace FSharp.Blazor

open System.IO
open System.Text.Encodings.Web
open System.Threading.Tasks
open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.ViewFeatures
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http.Features
open FSharp.Control.Tasks.V2.ContextInsensitive
open FSharp.Blazor

type FsBlazorMiddleware<'a when 'a :> Component>(next : RequestDelegate) =
    member this.InvokeAsync(context : HttpContext, html : IHtmlHelper) : Task =
        let syncIOFeature = context.Features.Get<IHttpBodyControlFeature>()
        if syncIOFeature <> null then
            syncIOFeature.AllowSynchronousIO <- true
        let vca = html :?> IViewContextAware
        let vc = ViewContext()
        vc.HttpContext <- context
        vca.Contextualize(vc)
        task {
            let! htmlContent = html.RenderComponentAsync<'a>(RenderMode.Static)
            context.Response.ContentType <- "text/html"
            let sw = new StreamWriter(context.Response.Body)
            htmlContent.WriteTo(sw , HtmlEncoder.Default)
            do! sw.FlushAsync()
        } :> Task

[<Extension>]
type FsBlazorMiddlewareExtensions =
    [<Extension>]
    static member UseFSharpBlazorServer<'a when 'a :> Component>(builder : IApplicationBuilder) =
        builder.UseStaticFiles() |> ignore
        builder.UseMiddleware<FsBlazorMiddleware<'a>>()

    [<Extension>]
    static member AddFSharpBlazorServer(services: IServiceCollection) =
        services.AddMvc() |> ignore
        services.AddServerSideBlazor() |> ignore
        services.AddHttpContextAccessor() |> ignore

