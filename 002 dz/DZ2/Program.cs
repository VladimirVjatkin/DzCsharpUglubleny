using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DZ2
{
    internal class Program
    {
        static int[,] Array2RandFill(int Min, int Max, int x, int y)
        {
            int[,] arr = new int[x, y];
            Random rand = new Random();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arr[j, i] = rand.Next(Min, Max);
                }

            }

            return arr;
        }

        static void PrintArr2(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        static void PrintArr1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            return;
        }


        static int[] Arr2ToArr1(int[,] arr)
        {
            int[] result = new int[arr.GetLength(0)*arr.GetLength(1)];
            int k = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result[k] = arr[i, j];
                    k++;
                }
            }

            return result;

        }

        static int[,] Arr1ToArr2(int[] arr, int NumS, int NumC)
        {
            int[,] result = new int[NumS, NumC];
            int k = 0;

            for (int i = 0; i < NumS; i++)
            {
                for (int j = 0; j < NumC; j++)
                {
                    result[i, j] = arr[k];
                    k++;

                }
            }

         return result;
        }

        static int[] SortArr1(int[] arr)
        {
            //самая простая сортировка:
            //Array.Sort(arr);

            // либо можем это сделать ручками, не знаю как надо))
            // сортировка выбором максимального значения и размещение его в конец массива.
            // предполагается что значения в массиве будут больше 0., можно в принципе переделать и на отрицательные.

            int index = 0;
            int length = arr.Length;
            int[] arrsort = new int[length];

            for(int k = length - 1; k >= 0; k--)
            {
                int max = arr[0];
                index = 0;
                for (int i = 1; i < length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                        index = i;
                    }
                }
                arr[index] = 0;
                arrsort[k] = max;
                
                
            }
            
            return arrsort;
        }


        static void Main(string[] args)
        {
            
            // простой случай #################################
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            PrintArr2(a);
            Console.WriteLine();

            int[] arrSimple = Arr2ToArr1(a);

            PrintArr1(arrSimple);
            Console.WriteLine();
            int[] arrsortSimple = SortArr1(arrSimple);
            Console.WriteLine("\nSIMPLE RESULT");
            int[,] ArrResultSimple = Arr1ToArr2(arrsortSimple, 3, 3);
            PrintArr2(ArrResultSimple);
            Console.WriteLine();


            // посложнее общий случай ################################
            Console.WriteLine("Difficult Random Case");
            int s = 6; //number of strings
            int c = 6; //number of colums

            //формируем случайный массив используя цифры от 11 - 99, потом печатаем.
            int[,] Array = Array2RandFill(11, 99, s, c);
            PrintArr2(Array);
            Console.WriteLine();

            // переводим массив в одномерный, и печатаем его
            int[] arr1 = Arr2ToArr1(Array);
            PrintArr1(arr1);
            Console.WriteLine();

            // сортируем одномерный массив
            int [] arrsort = SortArr1(arr1);


            // переводим в двухмерный массив и печатаем его
            Console.WriteLine("\nRESULT");
            int[,] ArrResult = Arr1ToArr2(arrsort,s,c);
            PrintArr2(ArrResult);
            Console.WriteLine();


        }
    }
}
