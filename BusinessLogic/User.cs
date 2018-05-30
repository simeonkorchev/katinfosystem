using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class User
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool HasResolution { get; set; }
        public HashSet<TokenScope> Scopes { get; set; }
        internal User(UserEntity user)
        {
            Id = user.Id;
            Username = user.username;
            Scopes = new HashSet<TokenScope>();
        }
    }
}
