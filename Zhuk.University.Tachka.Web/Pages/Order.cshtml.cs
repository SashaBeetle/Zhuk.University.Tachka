using Blazorise;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Core.Constants;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class OrderModel : PageModel
    {
        public Car Car { get; private set; }

        private readonly ILogger<OrderModel> _logger;


        private readonly IDbEntityService<Car> _carService;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderModel(IDbEntityService<Car> carService, ILogger<OrderModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
            _logger = logger;
        }
        public async Task OnGet(int id)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            Car = await _carService.GetById(id);
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Car.Rating += RatingRep.Rating;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _logger.LogTrace($"Added Rating for Car id={id}");
            await _carService.Update(Car);
            _logger.LogTrace("Updated DataBase(Car) in Order");
        }
       
    }
}
