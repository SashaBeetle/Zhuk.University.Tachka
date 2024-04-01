using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Database.Interfaces
{
    public interface IAvatarHelper
    {
        public Task<string> GetRandomAvatar();
    }
}
