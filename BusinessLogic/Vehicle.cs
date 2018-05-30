using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Vehicle
    {
        public Guid Id;
        public string Vin { get;}
        public string RegistrationNumber { get;}
        public int YearOfProduction { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public VehicleType VehicleType { get; }
        public string Description { get; }
        public Person Owner { get; }
        public double Tax { get; set; }

        internal Vehicle(VehicleEntity Vehicle)
        {
            Id = Vehicle.Id;
            Vin = Vehicle.vin;
            RegistrationNumber = Vehicle.registrationNumber;
            YearOfProduction = Vehicle.yearOfProduction;
            Manufacturer = Vehicle.manufacturer;
            Model = Vehicle.model;
            VehicleType = Vehicle.vehicleType;
            Description = Vehicle.description;
            Owner = new Person(Vehicle.owner);
            Tax = Vehicle.tax;
        }

        public String GetVehicleTypeAsString()
        {
            return VehicleType.ToString();
        }
    }
}
