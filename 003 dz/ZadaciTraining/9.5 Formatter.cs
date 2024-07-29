using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Formatter
    {
        public string Format(string input, int maxLength = 0)
        {
            if (maxLength > 0 && input.Length > maxLength)
            {
                return input.Substring(0, maxLength) + "...";
            }
            return input;
        }

        public string Format(int number, string format = "D")
        {
            return number.ToString(format);
        }

        public string Format(DateTime date, string format = "d")
        {
            return date.ToString(format);
        }
    }
}
