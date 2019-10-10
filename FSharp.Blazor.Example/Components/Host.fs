namespace FSharp.Blazor.Example.Components

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Http
open FSharp.Blazor
open FSharp.Blazor.Html
open FSharp.Blazor.App

type Host() =
    inherit Component()

    [<Inject>]
    member val HttpContextAccessor : IHttpContextAccessor = null with get, set

    override this.Render () =
        html [] [
            body [] [
                app<App> this.HttpContextAccessor.HttpContext
                script [ attr.src "_framework/blazor.server.js" ] []
            ]
        ]
