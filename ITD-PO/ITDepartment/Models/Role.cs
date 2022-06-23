using System.ComponentModel.DataAnnotations;

namespace ITDepartment.Models
{
    public class Role
    {
        public const int Admin = 1;
        public const int supervisor = 2;
        public const int user = 3;

        [Key]
        public int roleId { get; set; }
        [Required]
        public string roleName { get; set; }

        public string roleDesc { get; set; }

        public string message { get; set; }

        //navigation
        public List<User> users { get; set; }
    }
}
