using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Car : Dbitem
    {
        public string? Name { get; set; }
        public string? Model { get; set; }
        public decimal? Price { get; set; }
    }
}
