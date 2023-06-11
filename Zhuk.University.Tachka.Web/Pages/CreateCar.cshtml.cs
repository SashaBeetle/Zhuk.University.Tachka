using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly TachkaDbContext _dbContext;


        private LocationHelper LocHelper = new LocationHelper();

        private DateTime date = DateTime.Now;
        

        public CreateCarModel(IDbEntityService<Car> carService, TachkaDbContext dbContext)
        {
            _carService = carService;
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Colors = ColorsRep.GetAllColors().ToList();
            Years = YearHelper.GetYearsList().ToList();
        }

        public async Task<IActionResult> OnPost(List<IFormFile> photos)
        {

            string DateWithoutTime = date.ToShortDateString(); //ToString("dd / MM / yyyy");

            var result = await LocHelper.GetGeoInfo();
            var JObj = JObject.Parse(result);
            var city = (string)JObj["city"];

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var photoIds = new List<int>();
            foreach (var photo in photos)
            {
                if (photo == null || photo.Length == 0)
                {
                    return BadRequest("No file uploaded");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    var newPhoto = new Photo
                    {
                        FileName = photo.FileName,
                        ImageData = memoryStream.ToArray()
                    };

                    _dbContext.Photos.Add(newPhoto);
                    await _dbContext.SaveChangesAsync();

                    photoIds.Add(newPhoto.Id);
                }
            }

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
                UserId = User.Identity.Name
                //Photos = photoIds.Select(id => new Photo { Id = id }).ToList()
            });

            return new RedirectToPageResult("/Carlist");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var photo = new Photo
                {
                    FileName = file.FileName,
                    ImageData = memoryStream.ToArray()
                };

                // Додати фотографію до контексту БД (використовуйте ваш контекст БД)
                _dbContext.Photos.Add(photo);
                await _dbContext.SaveChangesAsync();

                return StatusCode(200, "Photo uploaded successfully");
            }
        }
    }

}
