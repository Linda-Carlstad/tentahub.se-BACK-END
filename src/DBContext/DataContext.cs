using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TentaHub.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }


        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<University> Universities { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

    }
}
