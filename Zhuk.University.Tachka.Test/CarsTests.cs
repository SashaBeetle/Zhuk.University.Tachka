﻿using Microsoft.EntityFrameworkCore;
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
        TachkaDbContext _dbContext;
        IOptions<AppConfig> _configuration;

        public CarsTests()
        {
            _carService = ResolveService<IDbEntityService<Car>>();
            _configuration = ResolveService<IOptions<AppConfig>>();
            _dbContext= ResolveService<TachkaDbContext>();
        }

        [TestMethod]

        public async Task Create()
        {
            //var cars = await _carService.Create(new Car()
            //{
            //    Name = "BMW",
            //    Model = "X5",
            //    Price= 1500,
            //});
        }

        [TestMethod]
        public async Task GetAllCars()
        {
            var cars = await _carService.GetAll().ToListAsync();
        }
    }
}
