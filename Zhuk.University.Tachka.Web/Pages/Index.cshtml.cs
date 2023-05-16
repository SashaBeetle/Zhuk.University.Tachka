using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class IndexModel : PageModel
    {

        public IList<Car> Cars { get; private set; }

        private readonly IDbEntityService<Car> _carService;

        public IndexModel(IDbEntityService<Car> carService)
        {
            _carService = carService;
        }
        public async Task OnGet()
        {
            Cars = await _carService.GetAll().ToListAsync();

        }
    }
}