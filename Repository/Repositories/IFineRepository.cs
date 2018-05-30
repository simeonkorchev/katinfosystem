using System;
using System.Collections.Generic;
using Persistence.Entities;
using Utils;

namespace Persistence.Repositories
{
    public interface IFineRepository : IRepository<FineEntity>
    {
        FineEntity Add(double DueAmount, string VehicleVin, UserEntity User, PersonEntity Debtor, VehicleEntity FinedVehicle, FineResource FineResource);
        void Remove(FineEntity FineEntity);
        IEnumerable<FineEntity> GetAllFinesForVehicle(String VIN);
        IEnumerable<FineEntity> GetAllFinesForPerson(Guid ownerId);
    }
}
