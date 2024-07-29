using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Safe
    {
        private string code;
        private decimal balance;

        public Safe(string initialCode)
        {
            code = initialCode;
            balance = 0;
        }

        private bool VerifyCode(string inputCode)
        {
            return inputCode == code;
        }

        public bool ChangeCode(string oldCode, string newCode)
        {
            if (VerifyCode(oldCode))
            {
                code = newCode;
                return true;
            }
            return false;
        }

        public bool Deposit(string inputCode, decimal amount)
        {
            if (VerifyCode(inputCode) && amount > 0)
            {
                balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(string inputCode, decimal amount)
        {
            if (VerifyCode(inputCode) && amount > 0 && balance >= amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
    }
}
