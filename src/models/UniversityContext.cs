using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TentaHub.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }


        public DbSet<University> Universities { get; set; } = null!;
    }
}
