using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities;
using static Persistence.UnitOfWork.UnitOfWorkProvider;
namespace BusinessLogic
{
    public class PersonsManager : IPersonsManager
    {
        public Person Add(string Egn, string FirstName, string MidName, string LastName, string Address)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                PersonEntity AddedPerson = unitOfWork.Persons.Add(Egn, FirstName, MidName, LastName, Address, new List<VehicleEntity>(), new List<FineEntity>());
                unitOfWork.Complete();
                return new Person(AddedPerson);
                
            });
        }

        public Person GetPersonByEgn(string Egn)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                PersonEntity WantedPerson = unitOfWork.Persons.GetPersonByEgn(Egn);
                if(WantedPerson == null)
                {
                    return null;
                }

                return new Person(WantedPerson);
            });
        }

        public void Remove(PersonEntity entity)
        {
            UsingUnitOfWork(unitOfWork =>
            {
                unitOfWork.Persons.Remove(entity);
                unitOfWork.Complete();
            });
        }

        public void TransferOwnership(Guid VehicleId, Guid currentOwnerId, Guid newOwnerId)
        {
            UsingUnitOfWork(unitOfWork =>
            {
                PersonEntity CurrentOwner = unitOfWork.Persons.Get(currentOwnerId);
                PersonEntity NewOwner = unitOfWork.Persons.Get(newOwnerId);
                VehicleEntity OwnedVehicle = unitOfWork.Vehicles.Get(VehicleId);

                unitOfWork.Persons.TransferOwnership(OwnedVehicle, CurrentOwner, NewOwner);
                unitOfWork.Complete();
            });
        }
    }
}
