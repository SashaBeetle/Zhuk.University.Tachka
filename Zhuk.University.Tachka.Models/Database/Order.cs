using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Order : Dbitem
    {
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
