using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zhuk.University.Tachka.Core.Interfaces;
using Zhuk.University.Tachka.Core.Services;
using Zhuk.University.Tachka.Models.Configuration;

namespace Zhuk.University.Tachka.Core
{
    public static class DIConfiguration
    {
        public static void RegisterCoreDependencies(this IServiceCollection services)
        {
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
        }

        public static void RegisterCoreConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppConfig>(configuration.GetSection("AppConfig"));
        }
    }
}
