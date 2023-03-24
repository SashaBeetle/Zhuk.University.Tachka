using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Core.Interfaces
{
    public interface ICar
    {
        IEnumerable<Car> GetCars();
    }
}
