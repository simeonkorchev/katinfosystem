using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Utils
{
    public class InputValidatorUtils
    {
        private static HorsePowerValidator hpValidator = new HorsePowerValidator();
        private static VinValidator vinValidator = new VinValidator();
        private static YearValidator yearValidator = new YearValidator();
        private static UserRegistrationValidator RegistrationValidator = new UserRegistrationValidator();

        public static bool validateHorsePower(int horsePower)
        {
            return hpValidator.validate(horsePower);
        }
        public static bool ValidatePersonDetails(String FirstName, String MidName, String LastName, String Egn, String Address)
        {
            return !string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(MidName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Egn) || string.IsNullOrEmpty(Address);
        }
        public static bool validateVIN(String VIN)
        {
            return vinValidator.validate(VIN);
        }

        public static bool validateUsernameAndPassword(string Username, string Password)
        {
            return RegistrationValidator.validate(Username, Password);
        }
        public static bool validateYear(int year)
        {
            return yearValidator.validate(year);
        }

        private class HorsePowerValidator : InputValidator<int>
        {
            public bool validate(int horsePower)
            {
                return horsePower > 0;
            }
        }

        private class VinValidator : InputValidator<String>
        {

            public bool validate(string t)
            {
                return t.Length == 10;
            }
        }

        private class YearValidator : InputValidator<int>
        {
            public bool validate(int t)
            {
                return t > 0 && t > 1895 && t <= DateTime.Now.Year;
            }
        }
        private interface IDualInputValidator<T, Y> 
        {
            bool validate(T input, Y anotherInput);
        }

        private class UserRegistrationValidator : IDualInputValidator<string, string>
        {
            private const int MIN_LENGHT = 5;

            public bool validate(string Username, string Password)
            {
                if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    return false;
                }
                if(Username.Length < MIN_LENGHT || Password.Length < MIN_LENGHT)
                {
                    return false;
                }

                return true;
            }
        }
    }

}
