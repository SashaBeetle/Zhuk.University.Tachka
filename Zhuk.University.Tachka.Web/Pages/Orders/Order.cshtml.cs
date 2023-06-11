using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages.Orders
{
    public class OrderModel : PageModel
    {
        public Car Car { get; private set; }
        public int ID { get; set;}


        private readonly IDbEntityService<Car> _carService;
        private readonly IDbEntityService<Order> _orderService;


        public OrderModel(IDbEntityService<Car> carService, IDbEntityService<Order> orderService)
        {
            _carService = carService;
            _orderService = orderService;
        }
        public async Task OnGet(int id)
        {
            Car = await _carService.GetById(id);
        }
        public async Task<IActionResult> OnPost(int id, DateTime startDate, DateTime endDate)
        {
   
           
            // Створення нового об'єкта CarBooking
            await _orderService.Create(new Order()
            {
                CarId = id,
                UserId = User.Identity.Name, // або отримайте ID користувача з контексту авторизації
                StartDate = startDate,
                EndDate = endDate
            });

            return new RedirectToPageResult("/Index");
        }
    }
}
