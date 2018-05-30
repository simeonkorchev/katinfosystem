using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Vehicle
    {
        private String VIN { get; set; }
        private Color color { get; set; }
        private int year { get; set; }
        private String registrationNumber { get; set; }
        private String manufactorer { get; set; }
        private String model { get; set; }
        private int horsePower { get; set; }

        public Vehicle(String VIN, Color color, int year, String registrationNumber, String manufactorer, String model, int horsePower)
        {
            this.validateInput(VIN, year, horsePower);
            this.color = color;
            this.year = year;
            this.registrationNumber = registrationNumber;
            this.manufactorer = manufactorer;
            this.model = model;
            this.horsePower = horsePower;
        }

        private void validateInput(string VIN, int year, int horsePower)
        {
            if (!InputValidatorUtils.validateVIN(VIN))
            {
                throw new ArgumentException("Въведеният ВИН номер е погрешен!");
            }

            if (!InputValidatorUtils.validateYear(year))
            {
                throw new ArgumentException("Въведената година не е правилна!");
            }

            if (!InputValidatorUtils.validateHorsePower(horsePower))
            {
                throw new ArgumentException("Конските сили трябва да са по-големи от 0!");
            }
        }

        public enum Color
        {
            WHITE = 0, GREY = 1, BLACK = 2, BLUE = 3, YELLOW = 4, RED = 5, GREEN = 6
        }
    }
}