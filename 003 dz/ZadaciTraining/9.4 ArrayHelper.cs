using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class ArrayHelper
    {
        private int[] array;

        public ArrayHelper(int[] array)
        {
            this.array = array;
        }

        public int Find(int value)
        {
            return Array.IndexOf(array, value);
        }

        public int Find(int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            throw new IndexOutOfRangeException();
        }

        public int Find(Predicate<int> predicate)
        {
            return Array.Find(array, predicate);
        }
    }
}
