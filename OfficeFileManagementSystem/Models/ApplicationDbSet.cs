using Microsoft.EntityFrameworkCore;

namespace OfficeFileManagementSystem.Models
{
    public class ApplicationDbSet: DbContext
    {
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Importance> importances { get; set; }
        public DbSet<IncomingFile> incomingFiles { get; set; }
        public DbSet<OutgoingFile> outgoingFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RSINGH;Database=OfficeFileSystem; Integrated Security=true; Trust Server Certificate= true");
        }
    }
}
