using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class CarsTests : TestBase
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CarsTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task GetAllCars_ShouldReturnAllCars()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync("/api/сar");
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(responseBody);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count > 0);
        }
    }
}
