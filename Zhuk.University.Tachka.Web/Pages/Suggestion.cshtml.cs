using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
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


        private readonly ILogger<SuggestionModel> _logger;
        private readonly IDbEntityService<Car> _carService;
        private LocationHelper LocHelper = new LocationHelper();


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SuggestionModel(IDbEntityService<Car> carService, ILogger<SuggestionModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
            _logger = logger;
        }
     
        public async Task OnGetAsync()
        {
            var result = await LocHelper.GetGeoInfo();
            var JObj = JObject.Parse(result);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var city = (string)JObj["city"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
