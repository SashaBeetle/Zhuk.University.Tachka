using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Helpers;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class YearHelperTests : TestBase
    {
        [TestMethod]
        public void GetYearsList_ShouldReturn_ListOfYears()
        {
            // Arrange
            var years = YearHelper.GetYearsList();

            // Act
            var yearsList = years.ToList();

            // Assert
            Assert.IsNotNull(yearsList);
            Assert.AreEqual(35, yearsList.Count);
            Assert.AreEqual(1990, yearsList[0]);
            Assert.AreEqual(2021, yearsList[31]);
        }
    }
}
