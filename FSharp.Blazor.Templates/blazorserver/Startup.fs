namespace FSharp.Blazor.Template

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open FSharp.Blazor
open FSharp.Blazor.Template
open FSharp.Blazor.Template.Data

type Startup () =

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddFSharpBlazorServer() |> ignore
        services.AddSingleton<WeatherForecastService>() |> ignore

    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore

        app.UseRouting() |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapBlazorHub() |> ignore
            ) |> ignore

        app.UseFSharpBlazorServer<Host>() |> ignore

