using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Web.Data;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class CarlistModel : PageModel
    {
        public IList<Car> Cars { get; private set; }


        private readonly IDbEntityService<Car> _carService;

        public CarlistModel(IDbEntityService<Car> carService) 
        {
           _carService = carService; 
        }
        public async Task OnGet()
        {
            Cars = await _carService.GetAll().ToListAsync();
        }
    }
}
