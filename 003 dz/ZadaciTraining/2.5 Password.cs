using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class Password
    {
        private string password;

        public string Value
        {
            get { return password; }
            set
            {
                if (IsValidPassword(value))
                    password = value;
                else
                    throw new ArgumentException("Invalid password. Must be at least 8 characters long and contain both letters and digits.");
            }
        }

        private bool IsValidPassword(string pwd)
        {
            return pwd.Length >= 8 && pwd.Any(char.IsLetter) && pwd.Any(char.IsDigit);
        }
    }
}
