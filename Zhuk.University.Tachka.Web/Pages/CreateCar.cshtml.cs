using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class CreateCarModel : PageModel
    {
        [BindProperty]
        public CreateCarRequest Car { get; set; }

        private readonly IDbEntityService<Car> _carService;
        
        public CreateCarModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _carService.Create(new Car()
            {
                Name = Car?.Name,
                Model= Car?.Model,
                Price= Car?.Price
            });
            return new RedirectToPageResult("/Carlist");
        }
    }
}
