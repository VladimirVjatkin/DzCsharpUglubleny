using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class BankAccount
    {
        private string accountNumber;
        private decimal balance;

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposit of {amount:C} successful. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawal of {amount:C} successful. New balance: {balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid withdrawal amount.");
                return false;
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}
