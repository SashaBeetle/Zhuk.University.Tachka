using Microsoft.Extensions.Options;
using Zhuk.University.Tachka.Core.Interfaces;
using Zhuk.University.Tachka.Models.Configuration;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class WeatherForecastTests : TestBase
    {
        IWeatherForecastService _weatherForecastService;
        IOptions<AppConfig> _configuration;

        public WeatherForecastTests()
        {
            _weatherForecastService = ResolveService<IWeatherForecastService>();
            _configuration = ResolveService<IOptions<AppConfig>>();
        }

        [TestMethod]
        public void Get_Forecast_Should_Return_AmountOfResults_From_Config()
        {
            var forecast = _weatherForecastService.GetRandomForecast();
            Assert.AreEqual(forecast.Count(), _configuration?.Value?.ForecastAmount);
        }
    }
}