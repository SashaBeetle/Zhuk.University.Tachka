using Microsoft.AspNetCore.Mvc;
using Slobodianiuk.University.Example.Core.Interfaces;
using Slobodianiuk.University.Example.Models.Weather;

namespace Slobodianiuk.University.Example.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _forecastService;

        public WeatherForecastController(IWeatherForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.GetRandomForecast();
        }
    }
}