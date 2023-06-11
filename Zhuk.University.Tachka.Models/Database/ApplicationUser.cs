using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Models.Database
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatarPath { get; set; }
    }
}
