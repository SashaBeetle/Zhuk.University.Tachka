using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Core.Interfaces
{
    public interface ICar
    {
        IEnumerable<Car> GetCars();
    }
}
