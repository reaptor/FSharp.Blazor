namespace FSharp.Blazor.Template.Pages

open Microsoft.AspNetCore.Components
open FSharp.Blazor
open FSharp.Blazor.Html
open FSharp.Blazor.Routing
open FSharp.Blazor.Template.Shared

type App() =
    inherit Component()

    override this.Render() = [
        comp<Router> [
            appAssembly<App>
            found (fun rd ->
                comp<RouteView> [ routeData rd; defaultLayout<MainLayout> ] [])
            notFound (fun () ->
                comp<LayoutView> [ layout<MainLayout> ] [
                    p [] [ text "Sorry, there's nothing at this address." ]
                ])
        ] []
    ]