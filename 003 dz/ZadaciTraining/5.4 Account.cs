using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class Account
    {
        protected decimal balance;

        public Account(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public abstract void CalculateInterest();
    }

    public class SavingsAccount : Account
    {
        private decimal interestRate;

        public SavingsAccount(decimal initialBalance, decimal interestRate) : base(initialBalance)
        {
            this.interestRate = interestRate;
        }

        public override void CalculateInterest()
        {
            balance += balance * interestRate;
        }
    }

    public class CreditAccount : Account
    {
        private decimal creditLimit;
        private decimal interestRate;

        public CreditAccount(decimal initialBalance, decimal creditLimit, decimal interestRate) : base(initialBalance)
        {
            this.creditLimit = creditLimit;
            this.interestRate = interestRate;
        }

        public override void CalculateInterest()
        {
            if (balance < 0)
            {
                balance -= Math.Abs(balance) * interestRate;
            }
        }
    }
}
