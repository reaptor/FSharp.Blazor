namespace FSharp.Blazor.Template.Shared

open FSharp.Blazor.Html
open FSharp.Blazor

type MainLayout() =
    inherit LayoutComponent()

    override this.Render () = [
        div [ attr.``class`` "sidebar" ] [
            comp<NavMenu> [] []
        ]
        div [ attr.``class`` "main" ] [
            div [ attr.``class`` "content px-4" ] [
                a [ attr.href "https://docs.microsoft.com/en-us/aspnet/"; attr.target "_blank" ] [ text "About" ]
            ]
            div [ attr.``class`` "content px-4" ] [
                compInstance this.Body
            ]
        ]
    ]
