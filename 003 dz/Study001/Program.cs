using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создайте класс "Книга" с полями "название" и "автор". Создайте объект этого класса и выведите информацию о книге.
            Book book = new Book();
            
            book.Title = "C# Programming";
            book.Author = "John Doe";
            book.Year = 2000;

            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Year: {book.Year}");
            Console.WriteLine();

            // rectangle
            Rectangle rect = new Rectangle(5,10);
            rect.Height = 10;
            rect.Width = 5;

            Console.WriteLine(rect.Area);
            Console.WriteLine(rect.Perimeter);
            Console.WriteLine();

            /* 1.3. Создайте класс "Студент" с полями "имя" и "возраст". 
         * Создайте несколько объектов этого класса и выведите информацию о студентах.*/

            Student student01 = new Student();
            student01.Name = "John Bairon";
            student01.Age = 18;

            Student student02 = new Student();
            student02.Name = "Barbora Nike";
            student02.Age = 20;

            Student student03 = new Student();
            student03.Name = "Michael Brown";
            student03.Age = 30;

            Console.WriteLine($"Student01 = {student01.Name}, {student01.Age}");
            Console.WriteLine($"Student02 = {student02.Name}, {student02.Age}");    
            Console.WriteLine($"Student03 = {student03.Name}, {student03.Age}");


            /* 1.4. Разработайте класс "Банковский счет" с полями "номер счета", "баланс" и методами для внесения и снятия денег. 
         * Создайте несколько счетов и выполните операции с ними. 
         * Подсказка: Используйте методы для изменения баланса и проверяйте достаточность средств при снятии. */
            Console.WriteLine("############################");
            Console.WriteLine();

            /*            account account01 = new account();
                        account01.NumberOfAccount = "1234567890";
                        account01.OwnerName = "John Doe";
                        account01.balance = 1000;

                        account account02 = new account();
                        account02.NumberOfAccount = "9876543210";
                        account02.OwnerName = "Barbora Nike";
                        account02.balance = 500;


                        account01.TransferMoney(account02, 300);

                        account02.TakeMoney(400);
                        account01.DepositMoney(2000);
              */

            BankAccount account01 = new BankAccount("222333", "JonDep", 1000);
            BankAccount account02 = new BankAccount("444555", "Barbora", 500);
            account01.WithdrowMoney(300);
            account02.Deposit(2000);
            Console.WriteLine($"{account01.OwnerName} balance: {account01.Balance} account: {account01.AccountNumber}");
            Console.WriteLine($"{account02.OwnerName} balance: {account02.Balance} account: {account02.AccountNumber}");
            Console.WriteLine("Transfer 500 from 02 to 01 account");  
            account02.TransferMoney(account01, 500);
            Console.WriteLine($"{account01.OwnerName} balance: {account01.Balance} account: {account01.AccountNumber}");


            Console.WriteLine();
            Console.WriteLine("###############################");
            Console.WriteLine();
            Auto Auto01 = new Auto("Audi", "A7", "blue", 2015, 60500);
            Auto Auto02 = new Auto("BMW", "X5", "black", 2020, 85000);
            Auto01.PrintAllInfo();
            Auto02.PrintAllInfo();

            Auto01.ActualMileage(50000);
            Auto02.ActualMileage(90000);



            Console.WriteLine();
            Console.WriteLine("############################");
            Console.WriteLine();




        }
    }
    }
