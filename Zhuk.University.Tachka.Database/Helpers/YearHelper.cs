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
            int currentYear = DateTime.Now.Year;
            return currentYear;
        }
        public static List<int> GetYearsList()
        {
            List<int> yearsList = new List<int>();

            for (int year = 1990; year <= ValidateTodayYear(); year++)
            {
                yearsList.Add(year);
            }

            return yearsList;
        }

    }
}
