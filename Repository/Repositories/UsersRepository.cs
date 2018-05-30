using Persistence;
using Persistence.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UsersRepository : Repository<UserEntity>, IUsersRepository
    {
        public UsersRepository(KatSystemDbContext context) : base(context)
        {
        }

        public UserEntity Add(string UserName, byte[] Password)
        {
            return Set.Add(new UserEntity
            {
                username = UserName,
                password = Password
            });
        }

        public UserEntity Get(string Username)
        {
            return Set.SingleOrDefault(u => u.username == Username);
        }
    }
}
