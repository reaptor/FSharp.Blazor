# Introduction
FSharp.Blazor is a thin F# layer on top of server-hosted [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). It enables you to write your Blazor views and logic in F#. 

# Getting started
Install [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download)

Create a new F# web project
```
dotnet new web -lang f#
```

Add FSharp.Blazor
```
dotnet add package FSharp.Blazor
```

Add The requires code to your Startup.fs file
```
open FSharp.Blazor

type Startup() =

    member this.ConfigureServices(services: IServiceCollection) =
        ()

    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseRouting() |> ignore

        app.UseEndpoints(fun endpoints ->
            // Remove
            endpoints.MapGet("/", fun context -> context.Response.WriteAsync("Hello World!")) |> ignore
            // Add
            endpoints.MapBlazorHub() |> ignore
            ) |> ignore

        // Add
        app.UseFSharpBlazorServer<Host>() |> ignore
```