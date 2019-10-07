namespace FsBlazor.TestApp.Pages

open FsBlazor.Html
open FsBlazor.Page
open FsBlazor.Html.attr
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Http

type Host() =
    inherit Page()

    [<Inject>]
    member val HttpContextAccessor : IHttpContextAccessor = null with get, set

    override this.Render () =
        html [] [
            body [] [
                app<Routes> this.HttpContextAccessor.HttpContext
                script [ src "_framework/blazor.server.js" ] []
            ]
        ]
