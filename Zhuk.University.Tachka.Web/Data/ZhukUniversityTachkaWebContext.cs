using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Web.Data
{
    public class ZhukUniversityTachkaWebContext : DbContext
    {
        public ZhukUniversityTachkaWebContext (DbContextOptions<ZhukUniversityTachkaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Zhuk.University.Tachka.Models.Database.Car> Car { get; set; } = default!;
        public DbSet<Zhuk.University.Tachka.Models.Database.Order> Order { get; set; } = default!;
    }
}
