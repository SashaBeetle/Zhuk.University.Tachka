using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Photo : Dbitem
    {
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        // Зв'язок з таблицею "Машини"
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
