namespace FsBlazor.TestApp.Pages

open FsBlazor.Html
open FsBlazor.Router

type Routes() =
    inherit Router()
    override this.Routes = [
        "/counter", comp<Counter> [] [] ]
    override this.NotFound = comp<``404``> [] []
