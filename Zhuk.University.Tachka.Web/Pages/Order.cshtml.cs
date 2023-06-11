using Blazorise;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class OrderModel : PageModel
    {
        public Car Car { get; private set; }
        

        private readonly IDbEntityService<Car> _carService;


        public OrderModel(IDbEntityService<Car> carService, IDbEntityService<Order> orderService)
        {
            _carService = carService;
        }
        public async Task OnGet(int id)
        {
            Car = await _carService.GetById(id);
            Car.Rating = Car.Rating + 0.1f;
            await _carService.Update(Car);
        }
       
    }
}
