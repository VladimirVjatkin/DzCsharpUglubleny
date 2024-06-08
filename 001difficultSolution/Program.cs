using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaCalculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double result = Calculate(args);
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write($"{args[i]} ");
            }
            
            Console.WriteLine($"= {result}");
        }

        static double Calculate(string[] args)
        {
            List<double> numbers = new List<double>();
            List<string> operations = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (i % 2 == 0)
                    numbers.Add(double.Parse(args[i]));
                else
                    operations.Add(args[i]);
            }

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i] == "*")
                {
                    numbers[i] = numbers[i] * numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    operations.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i] == "/")
                {   if (numbers[i+1]==0)
                    {
                        Console.WriteLine($"!!!Divide By Zero - {numbers[i]} / {numbers[i+1]} !!!!\nPlease control your formula in command line\n" +
                            $"!!! Rezult will be not corrected  !!!! ");
                        break;
                    }
                    numbers[i] = numbers[i] / numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    operations.RemoveAt(i);
                    i--;
                }
            }

            double result = numbers[0];

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i] == "+")
                    result += numbers[i + 1];
                else if (operations[i] == "-")
                    result -= numbers[i + 1];
            }

            return result;
        }
    }

}

