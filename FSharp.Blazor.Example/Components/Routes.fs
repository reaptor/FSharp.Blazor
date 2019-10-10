namespace FSharp.Blazor.Example.Components

open System
open FSharp.Blazor
open FSharp.Blazor.Html
open Microsoft.AspNetCore.Components
//open Microsoft.AspNetCore.Components.Routing

//type Routes() =
//    inherit Router()
//    override this.Routes = [
//        "/", comp<Index> [] []
//        "/counter", comp<Counter> [] []
//        ]
//    override this.NotFound = comp<``404``> [] []



open System.Collections.Generic
open FSharp.Blazor
open Microsoft.AspNetCore.Components
open System.Reflection

type Routes() =
    inherit Component()

    let getO () =

//        let rf = typedefof<RenderFragment<_>>
//        let rd = typedefof<RouteData>
//        let otype = rf.MakeGenericType(rd)
//        Activator.CreateInstance(otype, (fun x -> RenderFragment(fun rb -> ())))

//        let f = fun (routeData : RouteData) -> div [] [] :> obj
//
//        let invoker = f.GetType().GetMethod("Invoke")
//
//        RenderFragment()
//
//        let tArg = typeof<string>
//        let genericBase = typedefof<RenderFragment<_>>
//        let renderFragmentType = genericBase.MakeGenericType(tArg)
//        let mi = renderFragmentType.GetMethod("Invoke")
//
//
//        let d = Delegate.CreateDelegate(renderFragmentType, target, mi)

//        let r = Activator.CreateInstance(renderFragmentType, [|""|])

//        let invoker = f.GetType().GetMethod("Invoke")

//        let y = invoker.Invoke(renderFragmentType, [|"jjj" :> obj|])

        ()

    override this.Render() =
        comp<Microsoft.AspNetCore.Components.Routing.Router> [
            "AppAssembly" => this.GetType().Assembly
            "Found" => RenderFragment<RouteData>(fun (routeData : RouteData) ->
                RenderFragment(fun rb ->
                    comp<RouteView> [
                        "RouteData" => routeData
                    ] []
                    |> Render.RenderNodeWithSequence this rb 0 (Dictionary())
                    ()))
            "NotFound" => RenderFragment(fun rb ->
                Render.RenderNodeWithSequence this rb 0 (Dictionary()) (text "not found")
                ())
        ] []