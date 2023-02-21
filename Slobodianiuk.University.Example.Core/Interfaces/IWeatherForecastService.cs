using Zhuk.University.Tachka.Models.Weather;

namespace Zhuk.University.Tachka.Core.Interfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetRandomForecast();
    }
}
