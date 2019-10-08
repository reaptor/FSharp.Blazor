namespace FSharp.Blazor.Example.Components

open FSharp.Blazor
open FSharp.Blazor.Html

type Routes() =
    inherit Router()
    override this.Routes = [
        "/", comp<Index> [] []
        "/counter", comp<Counter> [] []
        ]
    override this.NotFound = comp<``404``> [] []
