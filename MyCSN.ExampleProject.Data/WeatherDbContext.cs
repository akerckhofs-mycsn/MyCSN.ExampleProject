using System;
using Microsoft.EntityFrameworkCore;
using MyCSN.ExampleProject.Data.Configurations;
using MyCSN.ExampleProject.Domain.Models;

namespace MyCSN.ExampleProject.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new WeatherForecastConfiguration());
        }
    }
}