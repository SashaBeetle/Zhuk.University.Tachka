using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class IndexModel : PageModel
    {

        public IList<Car> Cars { get; private set; }
        public IList<Car> RCars { get; private set; }


        private Random random = new Random();
        private int NumberOfBoxs = 3;

        private readonly IDbEntityService<Car> _carService;

        public IndexModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public async Task OnGet()
        {
            Cars = await _carService.GetAll().ToListAsync(); 
            RCars = Cars.OrderBy(x => random.Next()).Take(NumberOfBoxs).ToList();
        }
    }
}