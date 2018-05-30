using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IFinesManager
    {
        Fine Get(Guid Id);

        Fine Add(double DueAmount, string VehicleVin, Guid UserId, Guid DebtorId, Guid VehicleId, string FineResource);

        void Delete(Guid Id);

        IEnumerable<Fine> GetAllFinesForVehicle(String VIN);

        IEnumerable<Fine> GetAllFinesForPerson(Guid ownerId);
    }
}
