namespace FSharp.Blazor.Example.Components

open FSharp.Blazor.Html
open FSharp.Blazor

type ``404``() =
    inherit Component()
    override this.Render() =
        text "This page does not exist"

