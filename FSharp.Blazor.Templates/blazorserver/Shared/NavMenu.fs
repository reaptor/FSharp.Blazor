namespace FSharp.Blazor.Template.Shared

open FSharp.Blazor.Html
open FSharp.Blazor
open Microsoft.AspNetCore.Components.Routing
open Microsoft.AspNetCore.Components.Web

type NavMenu() =
    inherit LayoutComponent()

    let mutable collapseNavMenu = true

    let navMenuCssClass = fun () -> if collapseNavMenu then "collapse" else null

    let toggleNavMenu (e : MouseEventArgs) =
        collapseNavMenu <- not collapseNavMenu

    override this.Render () = [
        div [ attr.``class`` "top-row pl-4 navbar navbar-dark" ] [
            a [ attr.``class`` "navbar-brand"; attr.href "/" ] [ text "FSharp.Blazor.Template" ]
            button [ attr.``class`` "navbar-toggler"; on.click toggleNavMenu ] [
                span [ attr.``class`` "navbar-toggler-icon" ] []
            ]
        ]
        div [ attr.``class`` (navMenuCssClass()); on.click toggleNavMenu ] [
            ul [ attr.``class`` "nav flex-column" ] [
                li [ attr.``class`` "nav-item px-3" ] [
                    comp<NavLink> [ attr.``class`` "nav-link"; attr.href "/"; "Match" => NavLinkMatch.All ] [
                        span [ attr.``class`` "oi oi-home"; attr.``aria-hidden`` true ] []
                        text "Home"
                    ]
                ]
                li [ attr.``class`` "nav-item px-3" ] [
                    comp<NavLink> [ attr.``class`` "nav-link"; attr.href "counter" ] [
                        span [ attr.``class`` "oi oi-plus"; attr.``aria-hidden`` true ] []
                        text "Counter"
                    ]
                ]
                li [ attr.``class`` "nav-item px-3" ] [
                    comp<NavLink> [ attr.``class`` "nav-link"; attr.href "fetchdata" ] [
                        span [ attr.``class`` "oi oi-list-rich"; attr.``aria-hidden`` true ] []
                        text "Fetch data"
                    ]
                ]
            ]
        ]
    ]