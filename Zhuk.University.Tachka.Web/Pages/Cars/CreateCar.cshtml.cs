using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Zhuk.University.Tachka.Core.Constants;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class CreateCarModel : PageModel
    {
        [BindProperty]
        public CreateCarRequest Car { get; set; }

        public IEnumerable<string> Colors = ColorsRep.GetAllColors().ToList();
        public List<int> Years = YearHelper.GetYearsList().ToList();

        private readonly IDbEntityService<Car> _carService;

        private LocationHelper LocHelper = new LocationHelper();

        public CreateCarModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();           

            if (Car == null)
                return Page();
            
            if (Car.Photo == null)
                Car.Photo = "https://cdn.pixabay.com/photo/2018/02/27/16/23/car-3185869_640.png";
            

            var result = await LocHelper.GetGeoInfo();
            var JObj = JObject.Parse(result);
            var city = (string)JObj["city"];

            await _carService.Create(new Car()
            {
                Name = Car?.Name,
                Model = Car?.Model,
                Price = Car?.Price,
                Color = Car?.Color,
                Year = Car?.Year,
                Description = Car?.Description,
                PlacementTime = DateTime.Now.ToShortDateString(), // ToString("dd / MM / yyyy");
                PlacementCity = city,
                Rating = 0,
                UserId = User.Identity.Name,
                Photo = Car?.Photo
            });

            return new RedirectToPageResult("/Cars/Carlist");
        }

       
    }

}
