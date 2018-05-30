using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IVehiclesManager
    {
        Vehicle Create(string Vin, string RegistrationNumber, string Manufacturer, string Model, int YearOfProduction, string VehicleType, string Description, Guid OwnerId, double Tax);

        Vehicle GetVehicleByVin(String Vin);

        Vehicle AddTax(string Vin, double TaxAmount);

        Vehicle PayTax(string Vin, double TaxAmount);

        void Delete(Guid Id);
    }
}
