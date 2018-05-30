using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Motorcycle : Vehicle
    {

        public Motorcycle(String VIN, Color color, int year, String registrationNumber, String manufactorer, String model, int horsePower)
             : base(VIN, color, year, registrationNumber, manufactorer, model, horsePower)
        {}
    }
}
