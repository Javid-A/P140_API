using Microsoft.EntityFrameworkCore;
using P140_API.Entities;

namespace P140_API.DAL
{
    public class AcademyDbContext:DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options):base(options)
        {
            
        }
        public DbSet<Group> Groups { get; set; }
    }
}
