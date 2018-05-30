using Persistence.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbSet<T> Set { get; }

        protected DbContext dbContext;

        protected Repository(KatSystemDbContext context)
        {
            dbContext = context;
            Set = context.Set<T>();
        }

        public T Get(Guid id)
        {
            return Set.Find(id);
        }

    }
}
