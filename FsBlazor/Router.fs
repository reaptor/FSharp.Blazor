module FsBlazor.Router

open System
open FsBlazor
open Microsoft.AspNetCore.Components
open FsBlazor.Page

[<AbstractClass>]
type Router() =
    inherit Page()

    [<Inject>]
    member val NavigationManager : NavigationManager = null with get, set

    abstract Routes : (string * Node) list
    abstract NotFound : Node

    override this.Render () =
        let uri = Uri(this.NavigationManager.Uri)
        this.Routes
        |> Map.ofList
        |> Map.tryFind uri.AbsolutePath
        |> function
            | Some x -> x
            | None -> this.NotFound