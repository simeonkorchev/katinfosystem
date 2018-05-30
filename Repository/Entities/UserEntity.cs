

namespace Persistence.Entities
{


    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class UserEntity : Entity
    {
        [StringLength(25)]
        [Required, Index(IsUnique = true)]
        public string username { get; set; }
        [Required, Column(TypeName = "BINARY"), MaxLength(32)]
        public byte[] password { get; set; }

        /*private Role role { get; set; }
        private HashSet<Permission> permissions { get; set; }
        
        public User(String username, String password, Role role)
        {
            this.Username = username;
            this.Password = password;
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
    */
    }
 }