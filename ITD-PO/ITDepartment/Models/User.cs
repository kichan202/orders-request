using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ITDepartment.Models
{
    public class User
    {
        [Key]
        [ValidateNever]
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string name { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string lastName{ get; set; }
        [ValidateNever]
        public string ? email { get; set; }
        
        public DateTime dateCreated = DateTime.Now;
        [ValidateNever]
        public Boolean ? isActive { get; set; } = false;


        //Navigation Property
        /*link to the department*/
        [ValidateNever]
        public int DepartmentId { get; set; }
        [ValidateNever]
        public Department Department { get; set; }

        /*link to roles*/
        [ValidateNever]
        public int RoleId   { get; set; }
        [ValidateNever]
        public Role Role { get; set; }




    }
}
