using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class SuggestionModel : PageModel
    {
        public IList<Car> Cars { get; private set; }
        public List<Car> cityCars { get; private set; }
        public List<Car> topCars { get; private set; }


        private readonly ILogger _logger;
        private readonly IDbEntityService<Car> _carService;
        //private LocationHelper LocHelper = new LocationHelper();


        public SuggestionModel(IDbEntityService<Car> carService, ILogger logger)
        {
            _carService = carService;
            _logger = logger;
        }
        //public async void OnGet()
        //{
        //    //var result = await LocHelper.GetGeoInfo();
        //    //var JObj = JObject.Parse(result);
        //    var city = "Zolochiv";

        //    Cars = await _carService.GetAll().ToListAsync();
        //    cityCars = Cars.Where(c => c.PlacementCity == city).ToList();
        //}
        public async Task OnGetAsync()
        {
            var city = "Zolochiv";
                _logger.LogInformation($"Parsed API Json, get city = {city}");

            Cars = await _carService.GetAll().OrderByDescending(c => c.Rating).ToListAsync();
            cityCars = Cars.Where(c => c.PlacementCity == city)
                   .OrderByDescending(c => c.Rating)
                   .ToList();
                        _logger.LogTrace("Sorting Cars in Suggestion");

            topCars = Cars.Take(9).ToList();

        }
    }
}
