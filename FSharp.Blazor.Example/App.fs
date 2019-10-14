namespace FSharp.Blazor.Example

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Forms
open FSharp.Blazor
open FSharp.Blazor.Html
open FSharp.Blazor.Routing

type App() =
    inherit Component()

    member val Text = "" with get, set

    override this.Render() = concat [
        input [ bind this.Text ]
        button [ on.click (fun _ -> this.Text <- "hej")] []
    ]
