using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Helpers;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class LocationHelperTests
    {
        [TestMethod]
        public void GetLocation_ShouldReturnLocation()
        {
            // Arrange
            var location = new LocationHelper();

            // Act
            var locationList = location.GetGeoInfo();

            // Assert
            Assert.IsNotNull(locationList);
   
        }
    }
}
