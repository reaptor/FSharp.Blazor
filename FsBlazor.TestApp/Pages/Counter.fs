namespace FsBlazor.TestApp.Pages

open FsBlazor.Html
open FsBlazor.Page

type Counter() =
    inherit Page()

    let mutable count = 0

    override this.Render () =
        div [] [
            text "This is a counter"
            button [ on.click (fun _ ->
                count <- count + 1) ] [
                sprintf "Count is %d" count |> text
            ]
        ]
