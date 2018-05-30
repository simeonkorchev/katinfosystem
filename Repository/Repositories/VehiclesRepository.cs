using Persistence.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using System.Threading.Tasks;
using Utils;

namespace Persistence
{
    public class VehiclesRepository : Repository<VehicleEntity>, IVehiclesRepository
    {
        public VehiclesRepository(KatSystemDbContext context) : base(context)
        {
        }

        public VehicleEntity Add(string Vin, string RegistrationNumber, string Manufacturer, string Model,int YearOfProduction, VehicleType VehicleType,string Description, PersonEntity Owner, double Tax)
        {
            return Set.Add(new VehicleEntity
            {
                vin = Vin,
                registrationNumber = RegistrationNumber,
                yearOfProduction = YearOfProduction,
                vehicleType = VehicleType,
                manufacturer = Manufacturer,
                model = Model,
                description = Description,
                owner = Owner,
                tax = Tax
            });
        }

        private VehicleEntity RemoveByPerson(PersonEntity currentOwner)
        {
            VehicleEntity Entity = Set.Where(v => v.owner == currentOwner).Single();
            return Set.Remove(Entity);
        }
        
        public void Remove(VehicleEntity entity)
        {
            Set.Remove(entity);
        }

        public VehicleEntity GetVehicleByVin(string Vin)
        {
            return Set
                .Include(v => v.owner)
                .SingleOrDefault(v => v.vin == Vin);
        }

        public VehicleEntity AddTax(string vin, double taxAmount)
        {
            throw new NotImplementedException();
        }
    }
}
