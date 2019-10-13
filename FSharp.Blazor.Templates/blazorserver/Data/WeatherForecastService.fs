namespace FSharp.Blazor.Template.Data

open System

type WeatherForecastService() =
    let summaries = [ "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" ]

    member this.GetForecastAsync(startDate : DateTime) =
        let rng = new Random()
        [ for i in 1 .. 5 do
            yield {
                Date = startDate.AddDays(float i)
                TemperatureC = rng.Next(-20, 55)
                Summary = summaries.[rng.Next(summaries.Length)]
            }
        ] |> async.Return
