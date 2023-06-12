using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class AboutModel : PageModel
    {
        readonly ILogger<AboutModel> _logger;
        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogTrace("Open About page");
        }
    }
}