using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class InputValidatorUtils
    {
        private static HorsePowerValidator hpValidator = new HorsePowerValidator();
        private static VinValidator vinValidator = new VinValidator();
        private static YearValidator yearValidator = new YearValidator();


        public static bool validateHorsePower(int horsePower)
        {
            return hpValidator.validate(horsePower);
        }

        public static bool validateVIN(String VIN)
        {
            return vinValidator.validate(VIN);
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
    }

}
