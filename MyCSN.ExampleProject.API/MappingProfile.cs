using AutoMapper;
using MyCSN.ExampleProject.API.Domain.DTO;
using MyCSN.ExampleProject.Domain.Models;

namespace MyCSN.ExampleProject.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<WeatherForecast, WeatherForecastDto>()?.ReverseMap();
        }
    }
}