using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Plugin.Validation
{
    public class Validator
    {
        public bool EmailValidation(string email)
        {
            string pattern = @"([a-zA-Z\d]+@[a-z]+\.[a-z]+)";

            if (!Regex.Match(email, pattern).Success)
            {
                return false;
            }
            return true;

        }

        public bool PasswordValidation(string password)
        {
            string pattern = @"([\\da-zA-Z\\./_])";

            if (!Regex.Match(password, pattern).Success)
            {
                return false;
            }
            return true;
        }
    }
}
