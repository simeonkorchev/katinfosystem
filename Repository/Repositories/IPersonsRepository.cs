using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IPersonsRepository : IRepository<PersonEntity>
    {
        PersonEntity Add(string Egn, string FirstName, String MidName, String LastName, String Address, ICollection<VehicleEntity> Vehicles, ICollection<FineEntity> Fines);

        void Remove(PersonEntity entity);

        PersonEntity GetPersonByEgn(string Egn);

        void AssignVehicleToPerson(PersonEntity Person, VehicleEntity Vehicle);

        void AssignFineToPerson(PersonEntity Person, FineEntity Fine);

        void TransferOwnership(VehicleEntity OwnedVehicle, PersonEntity currentOwner, PersonEntity newOwner);

    }
}
