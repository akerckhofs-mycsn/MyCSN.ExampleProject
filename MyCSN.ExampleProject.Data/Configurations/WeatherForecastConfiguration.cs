using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCSN.ExampleProject.Domain.Models;

namespace MyCSN.ExampleProject.Data.Configurations
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder) {
            if (builder == null)
                return;
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)?.ValueGeneratedOnAdd();
        }
    }
}