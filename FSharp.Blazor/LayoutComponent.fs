namespace FSharp.Blazor

open System.Collections.Generic
open Microsoft.AspNetCore.Components
open FSharp.Blazor
open FSharp.Blazor.Render

[<AbstractClass>]
type LayoutComponent() =
    inherit LayoutComponentBase()

    let matchCache = Dictionary()

    override this.BuildRenderTree(builder) =
        base.BuildRenderTree(builder)
        this.Render()
        |> Node.ForEach
        |> RenderNode this builder matchCache

    abstract Render : unit -> Node list

