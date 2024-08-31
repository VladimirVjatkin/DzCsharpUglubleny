using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{


    internal class BankAccount
    {
        /* 1.4. Разработайте класс "Банковский счет" с полями "номер счета", "баланс" и методами для внесения и снятия денег. 
        * Создайте несколько счетов и выполните операции с ними. 
        * Подсказка: Используйте методы для изменения баланса и проверяйте достаточность средств при снятии. */

        private string accountNr;
        private decimal balance;
        private string personName;
        public BankAccount(string accountNr, string personName, decimal initialbalance)
        {
            this.accountNr = accountNr;
            this.personName = personName;
            this.balance = initialbalance;
        }

        public string AccountNumber // Свойство для accountNumber
        {
            get { return accountNr; }
        }

        public string OwnerName // Свойство для ownerName
        {
            get { return personName; }
        }

        public decimal Balance // Свойство для ownerName
        {
            get { return balance; }
        }


        public void WithdrowMoney(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("You don't have enouph money, or unsoficient amount");
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("amount < 0, not possible");
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }



        public void TransferMoney(BankAccount targetAccount, decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                targetAccount.balance += amount;
                Console.WriteLine($"Transfer complete. {personName}'s balance is {balance:C}, and {targetAccount.OwnerName}'s balance is {targetAccount.balance:C}");
            }
            else
            {
                Console.WriteLine($"Not enough money. {personName} has only {balance:C}");
            }


        }
    }
}
