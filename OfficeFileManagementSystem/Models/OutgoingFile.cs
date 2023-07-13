using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeFileManagementSystem.Models
{
    public class OutgoingFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Out_Id { get; set; }
        [Required]
        public int Emp_Id { get; set; }
        [Required]
        public int Incoming_File_Id { get; set;}

        [Column("Date_Allowed", TypeName = "Date")]
        public DateTime Date_Allowed { get; set; }
    }
}
