using CourseManagement.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CourseManagement.Core.Interfaces;


namespace CourseManagement.Service.Data;

public class CourseDbContext(DbContextOptions<CourseDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(BaseEntity<int>).Assembly;

        var entityTypes = assembly.GetTypes()
            .Where(type =>
                type.IsClass &&
                !type.IsAbstract &&
                type.BaseType != null &&
                type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
            .ToList();

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }

        var asm = typeof(CourseDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(asm);
        
    }
}