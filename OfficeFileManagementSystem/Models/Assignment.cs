using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace OfficeFileManagementSystem.Models


{
 
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Assignment_Id { get; set; }
        [Required]
        public int Employee_Id { get; set; }
        [Required]

        
        [Column("Date_Allowed", TypeName="Date")]
        public DateTime Date_Allowed { get; set;}

        public int Incoming_File_Id { get; set; }
    }
}
