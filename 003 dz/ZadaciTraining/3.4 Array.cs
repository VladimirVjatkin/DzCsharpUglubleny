using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class ArrayProcessor
    {
        private int[] array;

        public ArrayProcessor(int size)
        {
            array = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 101); // Random numbers between 1 and 100
            }
        }

        public int FindMax()
        {
            return array.Max();
        }

        public int FindMin()
        {
            return array.Min();
        }

        public int FindMaxIndex()
        {
            return Array.IndexOf(array, array.Max());
        }

        public int FindMinIndex()
        {
            return Array.IndexOf(array, array.Min());
        }
    }
}
