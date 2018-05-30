using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Repositories;
using Repository.Repositories;

namespace Persistence.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        readonly KatSystemDbContext context;
        public IUsersRepository Users { get;  }
        public IVehiclesRepository Vehicles { get; }
        public IPersonsRepository Persons { get; }
        public IFineRepository Fines { get; }

        internal UnitOfWork(KatSystemDbContext context)
        {
            this.context = context;
            Users = new UsersRepository(context);
            Vehicles = new VehiclesRepository(context);
            Persons = new PersonsRepository(context);
            Fines = new FinesRepository(context);
        }

        
        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
