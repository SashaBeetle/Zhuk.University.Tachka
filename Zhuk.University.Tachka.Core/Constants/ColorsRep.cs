using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Core.Constants
{
    public static class ColorsRep
    {
        public static IEnumerable<string> GetAllColors()
        {
            return new List<string>()
            {
            "White",
            "Black",
            "Red",
            "Yellow",
            "Blue",
            "Green",
            "Orange",
            "Purple",
            "Gray",
            "Brown"
            };
        }
       
    }
}
