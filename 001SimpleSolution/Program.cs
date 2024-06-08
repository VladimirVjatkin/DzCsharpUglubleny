using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppTEST001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                

                //Написать программу-калькулятор, вычисляющую выражения вида a + b, a - b, a / b, a * b,
                //введенные из командной строки, и выводящую результат выполнения на экран.

                int num1 = int.Parse(args[0]);
                int num2 = int.Parse(args[2]);
                char znak = char.Parse(args[1]);
                int rezult = 0;
                if (num2 == 0 && znak == '/') { 
                    Console.WriteLine("Divide /0 - that is not possible"); 
                    return;
                }
                switch (znak)
                {
                    case '+':
                        rezult = num1 + num2;
                        break;
                    case '-':
                        rezult = num1-num2;
                        break;
                    case '*':
                        rezult = num1*num2;
                        break;
                    case '/':
                        rezult = num1/num2;
                        break;
                    case '%':
                        rezult = num1%num2;
                        break;
                    default:
                        Console.WriteLine($" {znak} - we don't understand it");
                        break;

                }
                Console.WriteLine($"{num1} {znak} {num2} = {rezult}");

            }
            else Console.WriteLine("We need integer arguments - example 1 + 2");
        }
    }
}
