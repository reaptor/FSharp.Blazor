namespace FSharp.Blazor.Example.Components

open Microsoft.AspNetCore.Components
open FSharp.Blazor.Html
open FSharp.Blazor

[<Route("/counter")>]
type Counter() =
    inherit Component()

    let mutable count = 0

    override this.Render () =
        div [] [
            text "This is a counter"
            button [ on.click (fun _ ->
                count <- count + 1) ] [
                sprintf "Count is %d" count |> text
            ]
        ]
