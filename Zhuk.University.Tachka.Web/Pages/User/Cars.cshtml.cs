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
        public UserCarsModel(IDbEntityService<Car> carService, ILogger<UserCarsModel> logger)
        {
            _carService = carService;
            _logger = logger;
        }
        public async Task OnGet()
        {
            _logger.LogTrace("Open User Cars page for(" + User.Identity.Name + ")");
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
            _logger.LogDebug($"Started Action: Delete car in User Cars from ({User.Identity.Name})");
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
