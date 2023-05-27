using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zhuk.University.Tachka.Database.Helpers;

namespace Zhuk.University.Tachka.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsApiController : Controller
    {
        public async Task<IActionResult> LocationExample()
        {
            LocationHelper LocHelper = new LocationHelper();
            var result = await LocHelper.GetGeoInfo();
            return View();
        }
    }
}
