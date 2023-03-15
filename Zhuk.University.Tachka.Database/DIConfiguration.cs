using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Database.Services;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Database
{
    
    public static class DIConfiguration
    {
        public static void RegisterDatabaseDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<TachkaDbContext>((x)=> x.UseSqlServer(configuration.GetConnectionString("TachkaDatabase")));

            services.AddScoped(typeof(IDbEntityService<>), typeof(DbEntityService<>));
             
                
        }
    }
}
