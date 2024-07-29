using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class DateAnalyzer
    {
        private DateTime date;

        public DateAnalyzer(int day, int month, int year)
        {
            date = new DateTime(year, month, day);
        }

        public bool IsLeapYear()
        {
            return DateTime.IsLeapYear(date.Year);
        }

        public string GetDayOfWeek()
        {
            return date.DayOfWeek.ToString();
        }
    }
}
