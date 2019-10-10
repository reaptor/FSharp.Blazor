namespace FSharp.Blazor.Example.Components

open FSharp.Blazor
open FSharp.Blazor.Html
open Microsoft.AspNetCore.Components

[<Route("foo")>]
type Index() =
    inherit Component()

    override this.Render () =
        div [] [
            p [] [
                text "This is a the start page"
            ]
            p [] [
                a [ attr.href "/counter" ] [ text "Go to counter page" ]
            ]
        ]
