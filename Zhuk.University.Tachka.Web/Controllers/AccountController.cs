using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Web.Pages.Account;

namespace Zhuk.University.Tachka.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IDbEntityService<User> _UserService;
        public AccountController(IDbEntityService<User> UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
