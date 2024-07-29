using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    using System.Text.RegularExpressions;

    public class EmailAccount
    {
        private string email;
        private string password;

        public EmailAccount(string email, string initialPassword)
        {
            if (IsValidEmail(email))
            {
                this.email = email;
                this.password = initialPassword;
            }
            else
            {
                throw new ArgumentException("Invalid email format");
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == password)
            {
                password = newPassword;
                return true;
            }
            return false;
        }

        public bool SendEmail(string inputPassword, string recipient, string subject, string body)
        {
            if (inputPassword == password)
            {
                Console.WriteLine($"Email sent to {recipient}");
                return true;
            }
            return false;
        }
    }
}
