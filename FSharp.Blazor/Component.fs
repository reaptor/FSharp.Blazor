namespace FSharp.Blazor

open System.Collections.Generic
open Microsoft.AspNetCore.Components
open FSharp.Blazor
open FSharp.Blazor.Render

[<AbstractClass>]
type Component() =
    inherit ComponentBase()

    let matchCache = Dictionary()

    override this.BuildRenderTree(builder) =
        base.BuildRenderTree(builder)
        this.Render()
        |> RenderNode this builder matchCache

    abstract Render : unit -> Node

