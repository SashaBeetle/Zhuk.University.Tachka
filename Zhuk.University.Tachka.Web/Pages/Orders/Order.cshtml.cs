using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Core.Constants;
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderModel(IDbEntityService<Car> carService, IDbEntityService<Order> orderService, ILogger<OrderModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
            _orderService = orderService;
            _logger = logger;
        }
        public async Task OnGet(int id)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            Car = await _carService.GetById(id);
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _logger.LogTrace($"Take order id from ({User.Identity.Name}) id = {id}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }
        public async Task<IActionResult> OnPost(int id, DateTime startDate, DateTime endDate)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _logger.LogDebug($"Started Action: Add order from ({User.Identity.Name})");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            DateTime today = DateTime.Today;
            if (startDate < today)
            {
                _logger.LogError($"Redirected User({User.Identity.Name}) to /Error page ");
                return new RedirectToPageResult("/Error");
            }


            _logger.LogInformation($"Creating Order by {User.Identity.Name}");
#pragma warning disable CS8601 // Possible null reference assignment.
            await _orderService.Create(new Order()
            {
                CarId = id,
                UserId = User.Identity.Name, // Name користувача з контексту авторизації
                StartDate = startDate,
                EndDate = endDate
            });
#pragma warning restore CS8601 // Possible null reference assignment.

#pragma warning disable CS8601 // Possible null reference assignment.
            Car = await _carService.GetById(id);
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Car.Rating += RatingRep.UpRating;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _carService.Update(Car);

            _logger.LogInformation($"Ending Creating Order by {User.Identity.Name}");

            _logger.LogTrace($"Redirect User({User.Identity.Name}) from /Order to /Index");
            return new RedirectToPageResult("/Index");
        }
    }
}
