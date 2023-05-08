using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepoTrialS10032023_1352.Models
{
  
        [Table("EmployeeT")]
        public class Employee
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Employee Name required")]
            [StringLength(32)]
            public string EmployeeName { get; set; }

            [Required(ErrorMessage = "EmployeeRole required")]
            [StringLength(20)]
            public string Role { get; set; }
            public int RoleID { get; set; }
        }
}
