namespace FSharp.Blazor.Template.Pages

open Microsoft.AspNetCore.Components
open FSharp.Blazor
open FSharp.Blazor.Html

[<Route("/")>]
type Index() =
    inherit Component()

    override this.Render () = [
        h1 [] [ text "Hello, world!" ]
        text "Welcome to your new app."
    ]