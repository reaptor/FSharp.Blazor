namespace FSharp.Blazor.Template.Pages

open Microsoft.AspNetCore.Components
open FSharp.Blazor.Html
open FSharp.Blazor

[<Route("/counter")>]
type Counter() =
    inherit Component()

    let mutable currentCount = 0

    let incrementCount _ = currentCount <- currentCount + 1

    override this.Render () = [
        h1 [] [ text "Counter" ]
        p [] [ sprintf "Current count: %i" currentCount |> text ]
        button [ attr.``class`` "btn btn-primary"; on.click incrementCount ] [ text "Click me" ]
    ]