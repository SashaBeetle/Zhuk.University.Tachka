using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Zhuk.University.Tachka.Web.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        public IList<Order> UserOrders { get; set; }
        public IList<Order> Orders { get; set; }

        private readonly ILogger<OrderModel> _logger;
        private readonly IDbEntityService<Order> _orderService;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrdersModel( IDbEntityService<Order> orderService, ILogger<OrderModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task OnGet()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            UserOrders = await _orderService.GetAll()
                .Where(c => c.UserId == User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _logger.LogTrace($"Sorted Orders in UserOrders");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Orders = await _orderService.GetAll()
                .Where(c => c.UserId != User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _logger.LogTrace($"Sorted Orders in Orders");

        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _logger.LogDebug($"Started Action: Delete order from ({User.Identity.Name})");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var order = await _orderService.GetById(id);
            _logger.LogTrace($"Take order id from ({User.Identity.Name}) id = {id}");

            if (order == null)
            {
                _logger.LogWarning($"NotFound order from ({User.Identity.Name}) id = {id}");
                return NotFound();
            }

            await _orderService.Delete(order);
            _logger.LogDebug($"End Action: order deleted from ({User.Identity.Name}) id = {id}");
            return RedirectToPage();
        }
    }
}
