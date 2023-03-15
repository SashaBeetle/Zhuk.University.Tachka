using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Configuration;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class CarsTests : TestBase
    {
        IDbEntityService<Car> _carService;
        IOptions<AppConfig> _configuration;
        TachkaDbContext _dbContext;

        public CarsTests()
        {
            _carService = ResolveService<IDbEntityService<Car>>();
            _dbContext = ResolveService<TachkaDbContext>();
            _configuration = ResolveService<IOptions<AppConfig>>();
        }

        [TestMethod]

        public async Task Create()
        {
            var cars = await _carService.Create(new Car()
            {
                Name = "BMW",
                Model = "X5",
                Price= 1500,
            });
        }

        [TestMethod]
        public async Task GetAllCars()
        {
            var cars = await _dbContext.Cars.ToListAsync();
        }
    }
}
