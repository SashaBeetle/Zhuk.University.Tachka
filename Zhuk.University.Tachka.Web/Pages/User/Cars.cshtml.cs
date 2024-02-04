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
        private readonly ILogger<UserCarsModel> _logger;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserCarsModel(IDbEntityService<Car> carService, ILogger<UserCarsModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
            _logger = logger;
        }
        public async Task OnGet()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _logger.LogTrace("Open User Cars page for(" + User.Identity.Name + ")");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            Cars = await _carService.GetAll()
                .Where(c => c.UserId == User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
            if(Cars == null)
            {
                
            }
            _logger.LogTrace($"Sorted Cars in User Cars page from ({User.Identity.Name})");
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _logger.LogDebug($"Started Action: Delete car in User Cars from ({User.Identity.Name})");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var car = await _carService.GetById(id);
            _logger.LogTrace($"Take Car id in User Cars from ({User.Identity.Name}) id = {id}");
            if (car == null)
            {
                _logger.LogWarning($"NotFound car in User Cars from ({User.Identity.Name}) id = {id}");
                return NotFound();
            }

            await _carService.Delete(car);
            _logger.LogDebug($"End Action: Car deleted in User Cars from ({User.Identity.Name}) id = {id}");
            return RedirectToPage();
        }
    }
}
