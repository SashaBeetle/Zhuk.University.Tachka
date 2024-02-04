using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class AvatarModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AvatarModel(UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public IFormFile AvatarFile { get; set; }

       
    }
}
