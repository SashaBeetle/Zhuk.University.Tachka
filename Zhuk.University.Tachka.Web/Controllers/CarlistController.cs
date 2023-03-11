using Microsoft.AspNetCore.Mvc;
using Zhuk.University.Tachka.Core.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using System.Linq;
using LinqToDB;

namespace Zhuk.University.Tachka.Web.Controllers
{
    public class CarlistController : Controller
    {
        private readonly DataContext _dataContext;

        public CarlistController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        
        public void AddCar(Car car)
        {
            


        }
        
       
    }
}
