using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using MyCSN.ExampleProject.API.Domain.DTO;
using MyCSN.ExampleProject.Data;
using MyCSN.ExampleProject.Domain.Models;

namespace MyCSN.ExampleProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly WeatherDbContext dbContext;
        private readonly IMapper mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDbContext dbContext, IMapper mapper) {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var weatherForecasts = await dbContext?.WeatherForecasts?.AsNoTracking().ToListAsync();
            var response = mapper?.Map<IEnumerable<WeatherForecastDto>>(weatherForecasts);

            if (weatherForecasts.Count == 0) NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddWeatherForecast(
            [FromBody] WeatherForecastCreateRequest weatherForecastRequest) {
            var weatherForecast = new WeatherForecast {
                Date = weatherForecastRequest.DateTime,
                TemperatureC = weatherForecastRequest.Temperature
            };

            try
            {
                dbContext?.WeatherForecasts?.Add(weatherForecast);
                await (dbContext?.SaveChangesAsync() ?? Task.CompletedTask);
            } catch (Exception e)
            {
                return StatusCode(500);
            }

            return StatusCode(201);
        }
    }
}