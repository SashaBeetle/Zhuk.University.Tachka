using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public static class YearHelper
    {
        private static int ValidateTodayYear()
        {
            return DateTime.Now.Year;
        }
        public static IEnumerable<int> GetYearsList()
        {
            for (int year = 1990; year <= ValidateTodayYear(); year++)
            {
                yield return year;
            }
        }
    }
}
