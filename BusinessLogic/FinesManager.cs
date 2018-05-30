using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities;
using static Persistence.UnitOfWork.UnitOfWorkProvider;

namespace BusinessLogic
{
    public class FinesManager : IFinesManager
    {
        public Fine Add(double DueAmount, string VehicleVin, Guid UserId, Guid DebtorId, Guid VehicleId, string FineResource)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                VehicleEntity Vehicle = unitOfWork.Vehicles.Get(VehicleId);
                UserEntity User = unitOfWork.Users.Get(UserId);
                PersonEntity Person = unitOfWork.Persons.Get(DebtorId);
                FineEntity Fine = unitOfWork.Fines.Add(DueAmount, VehicleVin, User, Person, Vehicle, (FineResource) Enum.Parse(typeof(FineResource), FineResource));
                unitOfWork.Complete();

                return new Fine(Fine);
            });
        }

        public void Delete(Guid Id)
        {
            UsingUnitOfWork(unitOfWork =>
            {
                FineEntity Fine = unitOfWork.Fines.Get(Id);
                unitOfWork.Fines.Remove(Fine);
                unitOfWork.Complete();
            });
        }

        public Fine Get(Guid Id)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                FineEntity Fine = unitOfWork.Fines.Get(Id);
                return new Fine(Fine);
            });
        }

        public IEnumerable<Fine> GetAllFinesForPerson(Guid ownerId)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                return unitOfWork.Fines.GetAllFinesForPerson(ownerId).Select(fine => new Fine(fine));
            });
        }

        public IEnumerable<Fine> GetAllFinesForVehicle(string VIN)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                return unitOfWork.Fines.GetAllFinesForVehicle(VIN).Select(fine => new Fine(fine));
            });   
        }
    }
}
