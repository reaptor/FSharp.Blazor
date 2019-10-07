namespace FsBlazor.TestApp.Pages

open FsBlazor.Html
open FsBlazor.Page

type ``404``() =
    inherit Page()
    override this.Render() =
        text "This page does not exist"

