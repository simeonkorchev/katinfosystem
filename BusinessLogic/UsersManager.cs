using Persistence.Entities;
using System;
using static Persistence.UnitOfWork.UnitOfWorkProvider;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static System.Text.Encoding;


namespace BusinessLogic
{
    class UsersManager : IUsersManager
    {

        public User Create(string username, string Password)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                UserEntity user = unitOfWork.Users.Add(username, ComputeHash(Password));
                unitOfWork.Complete();
                return new User(user);
            });
        }

        public User Edit(Guid Id, string Username, string Password)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                UserEntity user = unitOfWork.Users.Get(Id);
                user.password = ComputeHash(Password);
                user.username = Username;
                unitOfWork.Complete();
                
                return new User(user);
            }
            );
        }

        public User Login(string Username, string Password)
        {
            return UsingUnitOfWork(unitOfWork =>
            {
                UserEntity user = unitOfWork.Users.Get(Username);
                byte[] PasswordHash = ComputeHash(Password);
                if (user == null || ! (PasswordHash.SequenceEqual(user.password)))
                {
                    return null;
                }

                return new User(user);
            });
        }

        static byte[] ComputeHash(string input) => SHA256.Create().ComputeHash(UTF8.GetBytes(input));
    }
}
