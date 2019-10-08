namespace FSharp.Blazor

open System.IO
open System.Collections.Generic
open System.Text.Encodings.Web
open FSharp.Control.Tasks.V2.ContextInsensitive
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.ViewFeatures
open FSharp.Blazor
open FSharp.Blazor.Render

[<AbstractClass>]
type Component() =
    inherit ComponentBase()

    let matchCache = Dictionary()

    override this.BuildRenderTree(builder) =
        base.BuildRenderTree(builder)
        this.Render() |> RenderNode this builder matchCache

    abstract Render : unit -> Node

