namespace AspNetCore

open FsBlazor.TestApp.Pages
open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Mvc.ViewFeatures
open Microsoft.AspNetCore.Mvc
open  Microsoft.AspNetCore.Mvc.Razor
open Microsoft.AspNetCore.Mvc.Razor.Internal
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Mvc.ViewFeatures
open Microsoft.AspNetCore.Razor.Hosting
open Microsoft.AspNetCore.Mvc.ApplicationParts

type Views_Home_Index() =
    inherit RazorPage<obj>()

    [<RazorInject>]
    member val Html : IHtmlHelper = null

    override this.ExecuteAsync() =
        this.WriteLiteral("\nYOLO\n")
        async {
            let res = this.Html.RenderComponentAsync<Apa>(RenderMode.ServerPrerendered) |> Async.AwaitTask
            this.Write(res)
        } |> fun a -> Task.Run (fun () -> a |> Async.RunSynchronously)

//        this.Write(this.Html.RenderComponentAsync<Apa>(RenderMode.ServerPrerendered))
//		((RazorPageBase)this).Write((object)(await HtmlHelperComponentExtensions.RenderComponentAsync<Apa>(Html, (RenderMode)3)));
//		((RazorPageBase)this).WriteLiteral("\n</html>");
//        Task.CompletedTask


module Dummy =
    [<RazorCompiledItem(typeof<Views_Home_Index>, "mvc.1.0.view", "/Views/Home/Index.cshtml")>]
    [<ProvideApplicationPartFactory("Microsoft.AspNetCore.Mvc.ApplicationParts.CompiledRazorAssemblyApplicationPartFactory, Microsoft.AspNetCore.Mvc.Razor")>]
    do ()