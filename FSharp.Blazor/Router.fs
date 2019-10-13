module FSharp.Blazor.Routing

open System
open System.Reflection
open System.Collections.Generic
open Microsoft.AspNetCore.Components
open FSharp.Blazor
open FSharp.Blazor.Html

let appAssembly<'a> = "AppAssembly" => typeof<'a>.Assembly
let found (f : RouteData -> Node) = "Found" => f
let notFound (f : unit -> Node) = "NotFound" => f
let routeData routeData = "RouteData" => routeData
let defaultLayout<'a when 'a :> LayoutComponent> = "DefaultLayout" => typeof<'a>
let layout<'a when 'a :> LayoutComponent> = "Layout" => typeof<'a>

type Router() =
    inherit Component()

    [<Parameter>]
    member val AppAssembly : Assembly = null with get, set

    [<Parameter>]
    member val Found : (RouteData -> Node) = fun _ -> failwith "Property Found must be set" with get, set

    [<Parameter>]
    member val NotFound : (unit -> Node) = fun () -> failwith "Property NotFound must be set" with get, set

    override this.Render () = [
        comp<Microsoft.AspNetCore.Components.Routing.Router> [
            "AppAssembly" => this.AppAssembly
            "Found" => RenderFragment<RouteData>(fun (routeData : RouteData) ->
                RenderFragment(fun rb ->
                    this.Found routeData
                    |> Render.RenderNodeWithSequence this rb 0 (Dictionary())
                    ()))
            "NotFound" => RenderFragment(fun rb ->
                this.NotFound ()
                |> Render.RenderNodeWithSequence this rb 0 (Dictionary())
                )
        ] []
    ]