using System.ComponentModel.DataAnnotations;

namespace ITDepartment.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public string ? phoneNum { get; set; }

        //Navigation Property
        public List<User> Users { get; set; }
    }


}
