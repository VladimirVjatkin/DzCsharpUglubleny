using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class StringAnalyzer
    {
        private string text;

        public StringAnalyzer(string input)
        {
            text = input;
        }

        public int CountWords()
        {
            return text.Split(new char[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public string FindLongestWord()
        {
            return text.Split(new char[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                       .OrderByDescending(w => w.Length)
                       .FirstOrDefault();
        }
    }
}
