using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Security;
using Zhuk.University.Tachka.Core.Interfaces;
using Zhuk.University.Tachka.Models.Weather;

namespace Zhuk.University.Tachka.Web.Pages
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