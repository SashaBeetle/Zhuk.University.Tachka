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
        public OrdersModel( IDbEntityService<Order> orderService, ILogger<OrderModel> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task OnGet()
        {
            UserOrders = await _orderService.GetAll()
                .Where(c => c.UserId == User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
            _logger.LogTrace($"Sorted Orders in UserOrders");
            Orders = await _orderService.GetAll()
                .Where(c => c.UserId != User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
            _logger.LogTrace($"Sorted Orders in Orders");

        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            _logger.LogDebug($"Started Action: Delete order from ({User.Identity.Name})");
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
