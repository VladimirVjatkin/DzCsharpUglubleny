using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class BankAccount
    {
        protected decimal balance;

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public abstract void Deposit(decimal amount);
        public abstract bool Withdraw(decimal amount);

        public virtual decimal CalculateInterest()
        {
            return balance * 0.01m; // базовая процентная ставка 1%
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(decimal initialBalance) : base(initialBalance) { }

        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
            }
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {balance:C}");
                return true;
            }
            Console.WriteLine("Withdrawal failed. Insufficient funds.");
            return false;
        }

        public override decimal CalculateInterest()
        {
            return balance * 0.05m; // повышенная процентная ставка 5% для сберегательного счета
        }
    }

    public class CreditAccount : BankAccount
    {
        private decimal creditLimit;

        public CreditAccount(decimal initialBalance, decimal creditLimit) : base(initialBalance)
        {
            this.creditLimit = creditLimit;
        }

        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
            }
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > 0 && balance + creditLimit >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {balance:C}");
                return true;
            }
            Console.WriteLine("Withdrawal failed. Exceeds credit limit.");
            return false;
        }

        public override decimal CalculateInterest()
        {
            if (balance < 0)
            {
                return balance * 0.15m; // процентная ставка 15% на отрицательный баланс
            }
            return 0; // нет процентов на положительный баланс кредитного счета
        }
    }
}
