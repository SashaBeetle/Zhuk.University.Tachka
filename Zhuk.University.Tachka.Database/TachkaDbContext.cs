using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Database
{
    public class TachkaDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public TachkaDbContext() { }
        public TachkaDbContext(DbContextOptions<TachkaDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            //options.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}