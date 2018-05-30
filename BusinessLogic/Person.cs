using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Person
    {
        
        public String Egn { get;  }
        public String FirstName { get; }
        public String MidName { get; }
        public String LastName { get;}
        public String Address { get; }
        public Guid Id { get; }
        public IEnumerable<Fine> Fines { get; }
        public IEnumerable<Vehicle> Vehicles { get; }

        internal Person(PersonEntity person)
        {
            Id = person.Id;
            Egn = person.egn;
            FirstName = person.firstName;
            MidName = person.midName;
            LastName = person.lastName;
            Address = person.address;
            Fines = person.fines == null ? null : person.fines.Select(fine => new Fine(fine));
            Vehicles = person.vehicles == null ? null : person.vehicles.Select(vehicle => new Vehicle(vehicle));
        }
    }
}
