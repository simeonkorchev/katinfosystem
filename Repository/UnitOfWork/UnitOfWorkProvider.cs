using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public static class UnitOfWorkProvider
    {
        public static void UsingUnitOfWork(Action<IUnitOfWork> action)
        {
            UsingUnitOfWork((unitOfWork) 
                => {
                    action(unitOfWork);
                    return (object)null;
                });
        }

        public static T UsingUnitOfWork<T>(Func<IUnitOfWork, T> action)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new KatSystemDbContext()))
            {
                return action(unitOfWork);
            }
        }
    }
}
