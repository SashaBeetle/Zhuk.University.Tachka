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


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EditCarModel(IDbEntityService<Car> carService)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
        }
        public async Task OnGet(int id)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            OwnCar = await _carService.GetById(id);
#pragma warning restore CS8601 // Possible null reference assignment.

            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();
        }

        public async Task<IActionResult> OnPost(int id)
        {

#pragma warning disable CS8601 // Possible null reference assignment.
            OwnCar = await _carService.GetById(id);
#pragma warning restore CS8601 // Possible null reference assignment.


            if (Car.Photo == null)
            {
                Car.Photo = "https://cdn.pixabay.com/photo/2018/02/27/16/23/car-3185869_640.png";
            }

            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();



#pragma warning disable CS8602 // Dereference of a possibly null reference.
            OwnCar.Name = Car?.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            OwnCar.Model = Car?.Model;
            OwnCar.Price = Car?.Price;
            OwnCar.Color = Car?.Color;
            OwnCar.Year = Car?.Year;
            OwnCar.Description = Car?.Description;
            OwnCar.Photo = Car?.Photo;

            await _carService.Update(OwnCar);

            return new RedirectToPageResult("/User/Cars");
        }
    }
}
