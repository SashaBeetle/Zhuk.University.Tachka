using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Core.Interfaces
{
    public interface IUser
    {   
        IEnumerable<User> GetUsers();
    }
}
