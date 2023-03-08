using Microsoft.Extensions.Options;
using Zhuk.University.Tachka.Core.Constants;
using Zhuk.University.Tachka.Core.Interfaces;
using Zhuk.University.Tachka.Models.Configuration;
using Zhuk.University.Tachka.Models.Weather;

namespace Zhuk.University.Tachka.Core.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IOptions<AppConfig> _configuration;

        public WeatherForecastService(IOptions<AppConfig> configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<WeatherForecast> GetRandomForecast()
        {
            var amount = _configuration?.Value?.ForecastAmount ?? 1;

            return Enumerable.Range(1, amount).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = GetRandomSummary()
            })
            .ToArray();
        }

        private string GetRandomSummary()
        {
            return ProjectConstants.WeatherSummaries[Random.Shared.Next(ProjectConstants.WeatherSummaries.Length)];
        }
    }
}
