using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages.Orders
{
    public class OrderModel : PageModel
    {
        public Car Car { get; private set; }


        private readonly IDbEntityService<Car> _carService;
        private readonly IDbEntityService<Order> _orderService;
        private readonly ILogger<OrderModel> _logger;

        public OrderModel(IDbEntityService<Car> carService, IDbEntityService<Order> orderService, ILogger<OrderModel> logger)
        {
            _carService = carService;
            _orderService = orderService;
            _logger = logger;
        }
        public async Task OnGet(int id)
        {
            Car = await _carService.GetById(id);
            _logger.LogTrace($"Take order id from ({User.Identity.Name}) id = {id}");

        }
        public async Task<IActionResult> OnPost(int id, DateTime startDate, DateTime endDate)
        {
            _logger.LogDebug($"Started Action: Add order from ({User.Identity.Name})");

            DateTime today = DateTime.Today;
            if (startDate < today)
            {
                _logger.LogError($"Redirected User({User.Identity.Name}) to /Error page ");
                return new RedirectToPageResult("/Error");
            }


            _logger.LogInformation($"Creating Order by {User.Identity.Name}");
            await _orderService.Create(new Order()
            {
                CarId = id,
                UserId = User.Identity.Name, // Name користувача з контексту авторизації
                StartDate = startDate,
                EndDate = endDate
            });
            _logger.LogInformation($"Ending Creating Order by {User.Identity.Name}");

            _logger.LogTrace($"Redirect User({User.Identity.Name}) from /Order to /Index");
            return new RedirectToPageResult("/Index");
        }
    }
}
