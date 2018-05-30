using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFineRepository Fines { get; }
        IUsersRepository Users { get; }
        IVehiclesRepository Vehicles { get; }
        IPersonsRepository Persons { get; }

        void Complete();
    }
}
