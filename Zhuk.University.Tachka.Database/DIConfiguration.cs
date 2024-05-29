using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Database.Services;

namespace Zhuk.University.Tachka.Database
{
    
    public static class DIConfiguration
    {
        public static void RegisterDatabaseDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<TachkaDbContext>((x)=> x.UseSqlServer(configuration.GetConnectionString("TachkaDatabase")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped(typeof(IDbEntityService<>), typeof(DbEntityService<>));
            services.AddScoped<IAvatarHelper, AvatarHelper>();
        }

        public static void RegisterIdentityDependencies(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<TachkaDbContext>();
        }
    }
}
