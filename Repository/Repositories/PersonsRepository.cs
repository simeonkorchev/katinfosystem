using Persistence;
using Persistence.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories
{
    class PersonsRepository : Repository<PersonEntity>, IPersonsRepository
    {
        public PersonsRepository(KatSystemDbContext context) : base(context)
        {
        }

        public PersonEntity GetPersonByEgn  (string Egn)
        {
            return Set
                .Where(p => p.egn == Egn)
                .Include(p => p.fines)
                .Include(p => p.vehicles)
                .SingleOrDefault();
        }

        public PersonEntity Add(string Egn, string FirstName, String MidName, String LastName, String Address, ICollection<VehicleEntity> Vehicles, ICollection<FineEntity> Fines)
        {
            return Set.Add(new PersonEntity
            {
                egn = Egn,
                firstName = FirstName,
                midName = MidName,
                lastName = LastName,
                vehicles = Vehicles,
                address = Address,
                fines = Fines
            }
            );
        }

        public void Remove(PersonEntity entity)
        {
            Set.Remove(entity);
        }

        public void AssignVehicleToPerson(PersonEntity Person, VehicleEntity Vehicle)
        {
            PersonEntity PersonRecord = Set.SingleOrDefault(person => person.Id == Person.Id);
            PersonRecord.vehicles.Add(Vehicle);
        }

        public void AssignFineToPerson(PersonEntity Person, FineEntity Fine)
        {
            PersonEntity PersonRecord = Set.Single(person => person.Id == Person.Id);
            PersonRecord.fines.Add(Fine);            
        }

        public void TransferOwnership(VehicleEntity OwnedVehicle, PersonEntity currentOwner, PersonEntity newOwner)
        {
            PersonEntity CurrentOwnerEntity = Set.SingleOrDefault(person => person.Id == currentOwner.Id);
            PersonEntity NewOwnerEntity = Set.SingleOrDefault(person => person.Id == currentOwner.Id);
            CurrentOwnerEntity.vehicles.Remove(OwnedVehicle);
            NewOwnerEntity.vehicles.Add(OwnedVehicle);
            dbContext.Entry(CurrentOwnerEntity).State = EntityState.Modified;
            dbContext.Entry(NewOwnerEntity).State = EntityState.Modified;
        }
    }
}
