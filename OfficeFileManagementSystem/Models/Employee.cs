using Microsoft.AspNetCore.RateLimiting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeFileManagementSystem.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ? Emp_Id { get; set; }
        [DisplayName("Employee Name")]
        [Required]
        public string ? Employee_Name { get; set;}
        [DisplayName("Employee Designation")]
        [Required]

        public string ? Employee_Designation { get; set;}
        [MaxLength(10)]
        [DisplayName("Contact Number")]
        public int ? Contact_Number { get; set;}
        
    }
}
