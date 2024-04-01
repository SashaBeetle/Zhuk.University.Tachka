using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Zhuk.University.Tachka.Database.Helpers;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class IndexModel : PageModel
    {

        public IList<Car> Cars { get; private set; }
        public IList<Car> RCars { get; private set; }

        public string avatarUrl { get; private set; }


        private Random random = new Random();
        private int NumberOfBoxs = 3;

        private readonly ILogger<IndexModel> _logger;
        private readonly IDbEntityService<Car> _carService;
        private readonly IAvatarHelper _avatarHelper;


        public IndexModel(IDbEntityService<Car> carService, ILogger<IndexModel> logger, IAvatarHelper avatarHelper)
        {
            _carService = carService;
            _logger = logger;
            _avatarHelper = avatarHelper;
        }
        public async Task OnGet()
        {
            avatarUrl = await _avatarHelper.GetRandomAvatar();

            _logger.LogTrace("Open Home Page");
            Cars = await _carService.GetAll().ToListAsync(); 
            RCars = Cars.OrderBy(x => random.Next()).Take(NumberOfBoxs).ToList();
                _logger.LogTrace("Sorted Cars in Home Page");
        }
    }
}