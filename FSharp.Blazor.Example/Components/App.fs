namespace FSharp.Blazor.Example.Components

open Microsoft.AspNetCore.Components
open FSharp.Blazor
open FSharp.Blazor.Html
open FSharp.Blazor.Routing

type App() =
    inherit Component()

    override this.Render() =
        comp<Router> [
            appAssembly (this.GetType().Assembly)
            found (fun routeData ->
                comp<RouteView> [
                    "RouteData" => routeData
                ] [])
            notFound (fun () -> text "not found")
            ] []