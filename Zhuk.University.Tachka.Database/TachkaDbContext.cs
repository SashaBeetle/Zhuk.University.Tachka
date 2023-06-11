using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Database
{
    public class TachkaDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public TachkaDbContext() { }
        public TachkaDbContext(DbContextOptions<TachkaDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer("Server=tcp:tachka-server.database.windows.net,1433;Initial Catalog=Tachka;Persist Security Info=False;User ID=sqladmin;Password=Sasha2012;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}