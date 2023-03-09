using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Web.Data;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class CarlistModel : PageModel
    {
        private readonly Zhuk.University.Tachka.Web.Data.ZhukUniversityTachkaWebContext _context;

        public CarlistModel(Zhuk.University.Tachka.Web.Data.ZhukUniversityTachkaWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Car == null || Car == null)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
