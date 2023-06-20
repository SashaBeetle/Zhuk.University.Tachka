using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Web.Controllers;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class DatabaseTests : TestBase
    {
        [TestMethod]
        public void GetAllCars_ShouldReturnListOfCars()
        {
            // Arrange
            var mockCarService = new Mock<IDbEntityService<Car>>();
            mockCarService.Setup(service => service.GetAll().ToList())
                .Returns(new List<Car>
                {
                    new Car { Id = 1, Name = "Car 1" },
                    new Car { Id = 2, Name = "Car 2" },
                    new Car { Id = 3, Name = "Car 3" }
                });

            var controller = new CarController(mockCarService.Object);

            // Act
            var result = controller.GetAllCars();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = result;
            Assert.IsInstanceOfType(okResult, typeof(List<Car>));

            var cars = (List<Car>)okResult;
            Assert.AreEqual(3, cars.Count);
        }

    }
}
