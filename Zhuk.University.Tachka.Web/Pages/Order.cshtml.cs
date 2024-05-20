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


        public OrderModel(IDbEntityService<Car> carService, ILogger<OrderModel> logger)
        {
            _carService = carService;
            _logger = logger;
        }
        public async Task OnGet(int id)
        {
            Car = await _carService.GetById(id);
            Car.Rating += RatingRep.Rating;

            _logger.LogTrace($"Added Rating for Car id={id}");
            await _carService.Update(Car);
            _logger.LogTrace("Updated DataBase(Car) in Order");
        }
       
    }
}
