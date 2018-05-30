using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities;
using Persistence.Repositories;
using Repository;
using Utils;

namespace Persistence.Repositories
{
    public class FinesRepository : Repository<FineEntity>, IFineRepository
    {
        public FinesRepository(KatSystemDbContext context) : base(context)
        {
        }

        public IEnumerable<FineEntity> GetAllFinesForPerson(Guid ownerId)
        {
            return Set
                .Where(f => f.user.Id == ownerId)
                .Include(f => f.finedVehicle)
                .Include(f => f.debtor)
                .Include(f => f.user)
                .ToList();
        }

        public IEnumerable<FineEntity> GetAllFinesForVehicle(string VIN)
        {
            return Set
                .Where(f => f.vehicleVin == VIN)
                .Include(f => f.finedVehicle)
                .Include(f => f.debtor)
                .Include(f => f.user)
                .ToList();
        }

        public void Remove(FineEntity FineEntity)
        {
            Set.Remove(FineEntity);
        }

        public FineEntity Add(double DueAmount, string VehicleVin, UserEntity User, PersonEntity Debtor, VehicleEntity FinedVehicle, FineResource FineResource)
        {

            return Set.Add(new FineEntity 
            {
                dueAmount = DueAmount,
                vehicleVin = VehicleVin,
                user = User,
                debtor = Debtor,
                finedVehicle = FinedVehicle,
                fineResource = FineResource
            });
    }
    }
}
