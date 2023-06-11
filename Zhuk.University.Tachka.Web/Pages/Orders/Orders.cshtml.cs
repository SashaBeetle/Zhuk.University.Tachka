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
        private readonly IDbEntityService<Order> _orderService;
        public OrdersModel( IDbEntityService<Order> orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGet()
        {
            UserOrders = await _orderService.GetAll()
                .Where(c => c.UserId == User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
            Orders = await _orderService.GetAll()
                .Where(c => c.UserId != User.Identity.Name)
                .OrderByDescending(c => c.UserId)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderService.Delete(order);
            return RedirectToPage();
        }
    }
}
