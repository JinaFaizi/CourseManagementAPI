using CourseManagement.Core.Extensions;
using CourseManagement.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Service.Data;

public class DbContext(DbContextOptions<DbContext> options) 
    :  Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Lesson> Lessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RegisterAllEntitiesFromAssembly<BaseEntity>();

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DbContext).Assembly);
    }
}