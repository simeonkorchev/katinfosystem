using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Persistence.Entities;

namespace Persistence.Repositories
{
    public interface IVehiclesRepository : IRepository<VehicleEntity>
    {
        VehicleEntity Add(string Vin, string RegistrationNumber, string Manufacturer, string Model, int YearOfProduction, VehicleType VehicleType, string Description, PersonEntity Owner, double Tax);

        VehicleEntity GetVehicleByVin(string Vin);
        VehicleEntity AddTax(string vin, double taxAmount);
        VehicleEntity PayTax(string vin, double taxAmount);
        void Remove(VehicleEntity entity);
    }
}
