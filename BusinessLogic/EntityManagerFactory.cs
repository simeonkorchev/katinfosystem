using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class EntityManagerFactory
    {
        public static IPersonsManager PersonsManager { get; } = new PersonsManager();
        public static IFinesManager FinesManager { get; } = new FinesManager();
        public static IUsersManager UsersManager { get; } = new UsersManager();
        public static IVehiclesManager VehiclesManager { get; } = new VehiclesManager();
    }
}
