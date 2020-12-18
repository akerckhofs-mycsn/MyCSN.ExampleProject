using System;
using System.ComponentModel.DataAnnotations;

namespace MyCSN.ExampleProject.Domain.Models
{
    public class WeatherForecast
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}