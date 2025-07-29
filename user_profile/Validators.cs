using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace user_profile
{
    public static class Validators
    {
        public static bool IsValidInput(string? name)
        {
            return (!string.IsNullOrWhiteSpace(name)) && name.Length >= 1 ;
        }
        public static bool IsValidAge(string? inputAge, out int age)
        {
            age = 0;
            return (!string.IsNullOrWhiteSpace(inputAge)) && int.TryParse(inputAge, out age) && age >= 1 && age < 130;
        }
        public static bool IsValidEmail(string? email)
        {
            return (email.Count(c => c == '@') == 1) && email.Any(c => c == '.') && email.Length > 4;
        }
    }
}
