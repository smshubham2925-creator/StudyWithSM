using Microsoft.EntityFrameworkCore;
using StudyWithMe.Models;

namespace StudyWithMe.Data
{
    // ✅ Make sure it inherits DbContext
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudyMaterial> StudyMaterials { get; set; }
    }
}
