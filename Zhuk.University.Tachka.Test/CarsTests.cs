using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class CarsTests : TestBase
    {
        IDbEntityService<Car> _carService;
        TachkaDbContext _dbContext;
        private ILogger<CarsTests> _logger;

        public CarsTests()
        {
            _logger = ResolveService<ILogger<CarsTests>>(); 
            _carService = ResolveService<IDbEntityService<Car>>();
            _dbContext= ResolveService<TachkaDbContext>();
        }

        [TestMethod]

        public async Task Create()
        {
            _logger.LogDebug("Testing creation of a car.");

            var cars = await _carService.Create(new Car()
            {
                Name = "BMW",
                Model = "X5",
                Price = 1500,
            });
            _logger.LogDebug($"Created car with ID: {cars.Id}");

        }

        [TestMethod]
        public async Task GetAllCars()
        {
            _logger.LogInformation("Testing retrieval of all cars.");
            var car = await _carService.GetAll().ToListAsync();

        }
    }
}
