using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Dbitem
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Type = {GetType().Name}";
        }
    }
}
