using System;

namespace MyCSN.ExampleProject.API.Domain.DTO
{
    public class WeatherForecastDto
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}