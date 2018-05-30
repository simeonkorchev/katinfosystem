using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class User
    {
        private String username { get; set; }
        private String password { get; set; }
        private Role role { get; set; }
        private HashSet<Permission> permissions { get; set; }

        public User(String username, String password, Role role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            setPermissions();
        }

        private void setPermissions()
        {
            permissions = new HashSet<Permission>();
            if(this.role == Role.ADMINISTRATOR)
            {
                permissions.Add(Permission.READ_AND_WRITE);
                permissions.Add(Permission.READ);
                permissions.Add(Permission.WRITE);
                permissions.Add(Permission.DOWNLOAD);
            }
            else
            {
                permissions.Add(Permission.READ);
                permissions.Add(Permission.DOWNLOAD);
            }
        }
    }

    public enum Role
    {
        NORMAL=1, ADMINISTRATOR=2
    }
}
