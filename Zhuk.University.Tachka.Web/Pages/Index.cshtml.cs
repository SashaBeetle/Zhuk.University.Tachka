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

        private readonly ILogger<IndexModel> _logger;
        private readonly IDbEntityService<Car> _carService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IndexModel(IDbEntityService<Car> carService, ILogger<IndexModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _carService = carService;
            _logger = logger;
        }
        public async Task OnGet()
        {
                _logger.LogTrace("Open Home Page");
            Cars = await _carService.GetAll().ToListAsync(); 
            RCars = Cars.OrderBy(x => random.Next()).Take(NumberOfBoxs).ToList();
                _logger.LogTrace("Sorted Cars in Home Page");
        }
    }
}