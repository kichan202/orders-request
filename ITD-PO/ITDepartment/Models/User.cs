using System.ComponentModel.DataAnnotations;

namespace ITDepartment.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string lastName{ get; set; }

    }
}
