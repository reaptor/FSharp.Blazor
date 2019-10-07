module FsBlazor.Page

open System.IO
open System.Text.Encodings.Web
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.ViewFeatures
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.V2.ContextInsensitive
open Microsoft.AspNetCore.Components
open System.Collections.Generic
open FsBlazor
open FsBlazor.Render

[<AbstractClass>]
type Page() =
    inherit ComponentBase()

    let matchCache = Dictionary()

    override this.BuildRenderTree(builder) =
        base.BuildRenderTree(builder)
        this.Render() |> RenderNode this builder matchCache

    abstract Render : unit -> Node

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