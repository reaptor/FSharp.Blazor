namespace FSharp.Blazor.Example.Data

open System

type WeatherForecast = {
        Date : DateTime
        TemperatureC : int
        Summary : string
}
with
        member this.TemperatureF = 32 + int ((float this.TemperatureC) / 0.5556)