using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IUsersManager
    {
        User Login(string Username, string Password);
        User Create(string username, string Password);
        User Edit(Guid Id, string Username, string Password);
    }
}
