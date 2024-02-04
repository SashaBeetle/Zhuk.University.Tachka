using Blazorise;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using Zhuk.University.Tachka.Core.Constants;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;
using static IdentityServer4.Models.IdentityResources;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class CreateCarModel : PageModel
    {
        [BindProperty]
        public CreateCarRequest Car { get; set; }

        public IEnumerable<string> Colors { get; set; }
        public List<int> Years { get; set; }
        private readonly IDbEntityService<Car> _carService;


        private LocationHelper LocHelper = new LocationHelper();

        private DateTime date = DateTime.Now;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CreateCarModel(IDbEntityService<Car> carService)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
        }
        public void OnGet()
        {
            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Colors = ColorsRep.GetAllColors().ToList();
                Years = YearHelper.GetYearsList().ToList();

                return Page();
            }

            if (Car == null)
            {
                // ������� ��������, ���� ��'��� Car � ��������
                return Page();
            }

            if (Car.Photo == null)
            {
                Car.Photo = "https://cdn.pixabay.com/photo/2018/02/27/16/23/car-3185869_640.png";
            }

            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();

            string DateWithoutTime = date.ToShortDateString(); //ToString("dd / MM / yyyy");

            var result = await LocHelper.GetGeoInfo();
            var JObj = JObject.Parse(result);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var city = (string)JObj["city"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _carService.Create(new Car()
            {
                Name = Car?.Name,
                Model = Car?.Model,
                Price = Car?.Price,
                Color = Car?.Color,
                Year = Car?.Year,
                Description = Car?.Description,
                PlacementTime = DateWithoutTime,
                PlacementCity = city,
                Rating = 0,
                UserId = User.Identity.Name,
                Photo = Car?.Photo
            });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8601 // Possible null reference assignment.

            return new RedirectToPageResult("/Carlist");
        }

       
    }

}
