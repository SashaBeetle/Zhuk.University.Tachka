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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            Car car = await _carService.GetById(id);

            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            Car car = await _carService.GetById(id);

           _carService.Delete(car);

            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            await _carService.Create(car);

            return Ok(car);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            Car carToUpdate = await _carService.GetById(id);

            carToUpdate.Name = car.Name;
            carToUpdate.Model = car.Model;
            carToUpdate.Price = car.Price;
            carToUpdate.Color = car.Color;
            carToUpdate.Year = car.Year;
            carToUpdate.Description = car.Description;
            carToUpdate.Photo = car.Photo;


            await _carService.Update(carToUpdate);

            return Ok(carToUpdate);
        }
        
    }
}
