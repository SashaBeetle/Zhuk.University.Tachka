using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Helpers;

namespace Zhuk.University.Tachka.Test
{
    [TestClass]
    public class AvatarHelperTests
    {
        [TestMethod]
        public void GetRandomAvatar_ShouldReturnAvatarUrl()
        {
            // Arrange
            var avatarHelper = new AvatarHelper();

            // Act
            var avatarUrl = avatarHelper.GetRandomAvatar().ToString();

            // Assert
            Assert.IsNotNull(avatarUrl);
        }
    }
}
