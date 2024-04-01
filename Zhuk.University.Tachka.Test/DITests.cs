using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class DITests : TestBase
    {
        [TestMethod]
        public void Test_DI_Registration()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddScoped<IAvatarHelper, AvatarHelper>();

            // Act
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            var dataService = serviceProvider.GetService<IAvatarHelper>();
            Assert.IsNotNull(dataService);
            Assert.IsInstanceOfType<AvatarHelper>(dataService);
        }

        [TestMethod]
        public void Test_Singleton_Service_Registration()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddSingleton<IAvatarHelper, AvatarHelper>(); // Registering SingletonService

            // Act
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            var singletonService1 = serviceProvider.GetService<IAvatarHelper>();
            var singletonService2 = serviceProvider.GetService<IAvatarHelper>();

            Assert.IsNotNull(singletonService1);
            Assert.AreSame(singletonService1, singletonService2);
        }

        [TestMethod]
        public void Test_Scoped_Service_Registration()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddScoped<IAvatarHelper, AvatarHelper>(); // Registering ScopedService

            // Act
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedService1 = scope.ServiceProvider.GetService<IAvatarHelper>();
                var scopedService2 = scope.ServiceProvider.GetService<IAvatarHelper>();

                Assert.IsNotNull(scopedService1);
                Assert.AreSame(scopedService1, scopedService2);
            }
        }

        [TestMethod]
        public void Test_Transient_Service_Registration()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddTransient<IAvatarHelper, AvatarHelper>(); // Registering TransientService

            // Act
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            var transientService1 = serviceProvider.GetService<IAvatarHelper>();
            var transientService2 = serviceProvider.GetService<IAvatarHelper>();

            Assert.IsNotNull(transientService1);
            Assert.IsNotNull(transientService2);
            Assert.AreNotSame(transientService1, transientService2);
        }
    }
}
