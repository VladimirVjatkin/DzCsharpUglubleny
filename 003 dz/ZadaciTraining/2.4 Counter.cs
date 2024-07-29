using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Counter
    {
        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                if (value > count)
                    count++;
                else if (value < count)
                    count--;
            }
        }
    }
}
