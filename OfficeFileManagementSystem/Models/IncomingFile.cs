using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeFileManagementSystem.Models
{
    public class IncomingFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Incoming_File_Id { get; set; }

        [Required]

        public string ? FileName { get; set; }

        [Column("Date_Allowed", TypeName = "Date")]
        public DateTime Date_Allowed { get; set; }

        public string ?FileType { get; set; }

        public int Importance_ID { get; set; }
    }
}
