using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IPersonsManager
    {
        Person Add(string Egn, string FirstName, String MidName, String LastName, String Address);
        void Remove(PersonEntity entity);
        Person GetPersonByEgn(string Egn);
        void TransferOwnership(Guid VehicleId, Guid currentOwnerId, Guid newOwnerId);

    }
}
