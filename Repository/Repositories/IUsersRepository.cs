

namespace Persistence.Repositories
{
    using Persistence.Entities;
    public interface IUsersRepository : IRepository<UserEntity>
    {
        UserEntity Add(string Name, byte[] Password);

        UserEntity Get(string Username);

    }
}
