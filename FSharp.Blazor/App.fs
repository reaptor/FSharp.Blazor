module FSharp.Blazor.App

open System.IO
open System.Text.Encodings.Web
open FSharp.Control.Tasks.V2.ContextInsensitive
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.ViewFeatures
open FSharp.Blazor

let private renderComponentToStringAsync<'a when 'a :> IComponent>(httpContext : HttpContext) =
    let html = httpContext.RequestServices.GetService<IHtmlHelper>()
    let vca = html :?> IViewContextAware
    let vc = ViewContext()
    vc.HttpContext <- httpContext
    vca.Contextualize(vc)
    task {
        let! htmlContent = html.RenderComponentAsync<'a>(RenderMode.ServerPrerendered)
        let sw = new StringWriter()
        htmlContent.WriteTo(sw , HtmlEncoder.Default)
        do! sw.FlushAsync()
        return sw.ToString()
    }

let app<'a when 'a :> IComponent> (httpContext : HttpContext) =
    Html.elt "app" [] [
        (renderComponentToStringAsync<'a> httpContext).Result |> RawHtml
    ]