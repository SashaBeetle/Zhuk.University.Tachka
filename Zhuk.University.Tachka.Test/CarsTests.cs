using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using System.Net;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Web.Controllers;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class CarsTests : TestBase
    {
        [TestMethod]
        public async Task GetAllCars_Returns_Ok_With_Cars_List()
        {
            // Arrange
            var mockCarService = new Mock<IDbEntityService<Car>>();

            // Створюємо список автомобілів для повернення з сервісу
            var cars = new List<Car>
        {
            new Car { Id = 1, Name = "Toyota", Model = "Camry" },
            new Car { Id = 2, Name = "Honda", Model = "Civic" }
        };

            // Налаштовуємо поведінку мокованого сервісу для повернення списку автомобілів
            mockCarService.Setup(service => service.GetAll()).Returns(cars.AsQueryable());

            var controller = new CarController(mockCarService.Object);

            // Act
            IActionResult result = await controller.GetAllCars();

            // Assert
            Assert.IsInstanceOfType<OkObjectResult>(result); // Перевіряємо, що повертається об'єкт типу OkObjectResult

            OkObjectResult okResult = (OkObjectResult)result; // Приводимо результат до типу OkObjectResult

            Assert.IsNotNull(okResult.Value); // Перевіряємо, що значення в об'єкті OkObjectResult не є пустим

            List<Car> returnedCars = (List<Car>)okResult.Value; // Приводимо значення до типу List<Car>

            Assert.AreEqual(cars.Count, returnedCars.Count); // Перевіряємо, що кількість повернутих автомобілів відповідає кількості автомобілів у списку
        }
    }
}
