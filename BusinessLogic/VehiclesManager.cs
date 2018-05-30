using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities;
using Persistence.UnitOfWork;
using static Persistence.UnitOfWork.UnitOfWorkProvider;

namespace BusinessLogic
{
    class VehiclesManager : IVehiclesManager
    {
        public Vehicle AddTax(string Vin, double TaxAmount)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                VehicleEntity Entity = unitOfWork.Vehicles.AddTax(Vin, TaxAmount);
                unitOfWork.Complete();

                return new Vehicle(Entity);
            });
        }

        public Vehicle Create(string Vin, string RegistrationNumber, string Manufacturer, string Model, int YearOfProduction, string VehicleType, string Description, Guid OwnerId, double Tax)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                PersonEntity Owner = unitOfWork.Persons.Get(OwnerId);
                VehicleEntity VehicleEntity = unitOfWork.Vehicles.Add(Vin, RegistrationNumber, Manufacturer, Model, YearOfProduction, (VehicleType)Enum.Parse(typeof(VehicleType), VehicleType), Description, Owner, Tax);
                unitOfWork.Complete();

                return new Vehicle(VehicleEntity);

            });
        }

        public void Delete(Guid Id)
        {
            UsingUnitOfWork(unitOfWork =>
            {
                unitOfWork.Vehicles.Remove(unitOfWork.Vehicles.Get(Id));
            });
        }

        public Vehicle GetVehicleByVin(string Vin)
        {
            return UsingUnitOfWork(unitOfWork => 
            { 
                VehicleEntity entity = unitOfWork.Vehicles.GetVehicleByVin(Vin);
                if (entity == null) return null;
                return new Vehicle(entity);
            });
        }
    }
}
