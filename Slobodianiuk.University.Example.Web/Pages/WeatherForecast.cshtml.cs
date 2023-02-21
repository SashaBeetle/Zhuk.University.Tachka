using Microsoft.AspNetCore.Mvc.RazorPages;
using Slobodianiuk.University.Example.Core.Interfaces;
using Slobodianiuk.University.Example.Models.Weather;

namespace Slobodianiuk.University.Example.Web.Pages
{
    public class WeatherForecastModel : PageModel
    {
        public IList<WeatherForecast> Forecasts { get; set; }

        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastModel(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public void OnGet()
        {
            Forecasts = _weatherForecastService.GetRandomForecast().ToList();
        }
    }
}