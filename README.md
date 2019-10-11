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
*open FSharp.Blazor*

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        *services.AddServerSideBlazor() |> ignore*
      
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
          
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        *app.UseStaticFiles() |> ignore*

        app.UseRouting() |> ignore

        app.UseEndpoints(fun endpoints ->
            *endpoints.MapBlazorHub() |> ignore*
            *) |> ignore*

        *app.UseFSharpBlazorServer<Host>() |> ignore*

```