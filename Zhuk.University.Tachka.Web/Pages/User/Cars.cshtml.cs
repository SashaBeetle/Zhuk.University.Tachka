using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages.User
{
    public class UserCarsModel : PageModel
    {
        public IList<Car> Cars { get; private set; }


        private readonly IDbEntityService<Car> _carService;

        public UserCarsModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public async Task OnGet()
        {
            Cars = await _carService.GetAll()
                .Where(c => c.UserId == User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var order = await _carService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            await _carService.Delete(order);
            return RedirectToPage();
        }
    }
}
