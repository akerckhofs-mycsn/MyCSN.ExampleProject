using System;

namespace MyCSN.ExampleProject.API.Domain.DTO
{
    public class WeatherForecastCreateRequest
    {
        public DateTimeOffset DateTime { get; set; }
        public double Temperature { get; set; }
    }
}