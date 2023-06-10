using Blazorise;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Web.Controllers;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class OrderModel : PageModel
    {
        public Car Car { get; private set; }
        public IList<Car> Cars { get; private set; }



        private readonly IDbEntityService<Car> _carService;

        public OrderModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public async Task OnGet(int id)
        {
            Car = await _carService.GetById(id);
        }

    }
}
