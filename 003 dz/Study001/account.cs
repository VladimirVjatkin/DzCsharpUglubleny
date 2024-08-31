using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study001
{
    internal class account
    {
        internal object personName;

        /* 1.4. Разработайте класс "Банковский счет" с полями "номер счета", "баланс" и методами для внесения и снятия денег. 
* Создайте несколько счетов и выполните операции с ними. 
* Подсказка: Используйте методы для изменения баланса и проверяйте достаточность средств при снятии. */

        public string NumberOfAccount { get; set; }
        public string OwnerName { get; set; }
        public int balance { get; set; }

        public void TakeMoney(int amount)
        {

            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Transakce ok, now Balance is {balance}");
            }
            else
            {
                Console.WriteLine($"Not enouph money you have only {balance}");
            }

        }

        public void DepositMoney(int amount)
        {
            balance += amount;
            Console.WriteLine($" we add {amount} to your account, now balance is {balance}");
        }



        public void TransferMoney(account targetAccount, int amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                targetAccount.balance += amount;
                Console.WriteLine($"Transfer complete, now {OwnerName}'s balance is {balance}, and {targetAccount.OwnerName}'s balance is {targetAccount.balance}");
            }
            else
            {
                Console.WriteLine($"Not enouph money you have only {balance}");
            }

        }
    }
}
