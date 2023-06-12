using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class DatabaseTests : TestBase
    {
        private ILogger<DatabaseTests> _logger;
        private TachkaDbContext _dbContext;

        public DatabaseTests()
        {
            _logger = ResolveService<ILogger<DatabaseTests>>();
            _dbContext = ResolveService<TachkaDbContext>();
        }

        [TestMethod]
        public void GetAllItemsTest()
        {
            _logger.LogTrace("Testing retrieval of all items from the database.");

            
            var items = _dbContext.Cars;


            // Перерахувати та вивести усі елементи
            foreach (var item in items)
            {
                _logger.LogTrace($"Item: {item.Name}, Id: {item.Id}");
            }
        }
    }
}
