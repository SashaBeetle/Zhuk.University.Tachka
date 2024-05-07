using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Zhuk.University.Tachka.Core.Constants;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages.User
{
    public class EditCarModel : PageModel
    {
        [BindProperty]
        public CreateCarRequest Car { get; set; }

        public Car OwnCar { get; private set; }
        public IEnumerable<string> Colors { get; set; }
        public List<int> Years { get; set; }
        private readonly IDbEntityService<Car> _carService;


        public EditCarModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            OwnCar = await _carService.GetById(id);

            //if (OwnCar.UserId != User.Identity.Name)
            //{
            //    return RedirectToPage("/Error");
            //}

            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();

            return Page();

        }

        public async Task<IActionResult> OnPost(int id, string baner)
        {

            OwnCar = await _carService.GetById(id);

            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();

            if (Car.Photo == null)
            {
                Car.Photo = "https://cdn.pixabay.com/photo/2018/02/27/16/23/car-3185869_640.png";
            }

            
            OwnCar.Name = Car?.Name;
            OwnCar.Model = Car?.Model;
            OwnCar.Price = Car?.Price;
            OwnCar.Color = Car?.Color;
            OwnCar.Year = Car?.Year;
            OwnCar.Description = Car?.Description;
            OwnCar.Photo = Car?.Photo;

            await _carService.Update(OwnCar);

            TempData["ShowGreenBanner"] = true;
            TempData.Keep("ShowGreenBanner");

            return RedirectToPage("/User/EditCar", new { id = id });
            ;
        }
    }
}
