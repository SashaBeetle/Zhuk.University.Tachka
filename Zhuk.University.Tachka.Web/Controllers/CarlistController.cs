using Microsoft.AspNetCore.Mvc;
using Zhuk.University.Tachka.Core.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Controllers
{
    public class CarlistController : Controller
    {
        private readonly ICar _carService;

        public CarlistController(ICar carService)
        {
            _carService = carService;
        }
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Car> Get() 
        {
            return _carService.GetCars();
        }
        
       
    }
}
