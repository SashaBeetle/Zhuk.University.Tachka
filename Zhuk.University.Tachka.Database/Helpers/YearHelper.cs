using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public static class YearHelper
    {
        public static IEnumerable<int> GetYearsList()
        {
            for (int year = 1990; year <= DateTime.Now.Year; year++)
            {
                yield return year;
            }
        }
    }
}
