using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {

       
            private readonly IDbEntityService<Car> _carService;

            public CarController(IDbEntityService<Car> carService)
            {
                _carService = carService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllCars()
            {
                List<Car> cars = await _carService.GetAll().ToListAsync();

                return Ok(cars);
            }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            Car car = await _carService.GetById(id);

           _carService.Delete(car);

            return Ok(car);
        }
        
    }
}
