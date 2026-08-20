using CourseManagement.Service.Models;
using Microsoft.EntityFrameworkCore;


namespace CourseManagement.Service.Data;

public class CourseDbContext(DbContextOptions<CourseDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .Property(c => c.CoursePrice)
            .HasPrecision(18, 2);
    }
}