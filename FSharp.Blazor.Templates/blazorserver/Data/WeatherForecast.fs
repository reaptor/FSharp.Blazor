namespace FSharp.Blazor.Template.Data

open System

type WeatherForecast = {
        Date : DateTime
        TemperatureC : int
        Summary : string
}
with
        member this.TemperatureF = 32 + int ((float this.TemperatureC) / 0.5556)