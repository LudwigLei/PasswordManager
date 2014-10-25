using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PWManager.Security
{
    public static partial class Security
    {
        public static string EncryptPassword(string pw)
        {
            return CreateHash(pw);
        }

        public static bool PasswordValdation(string pw, string hash)
        {
            return ValidatePassword(pw, hash);
        }
    }
}
