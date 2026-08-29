using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Core.Extensions;

public static class ModelBuilderExtensions
{
    public static void RegisterAllEntitiesFromAssembly<T>(
        this ModelBuilder modelBuilder)
    {
        var assembly = typeof(T).Assembly;

        var entityTypes = assembly
            .GetTypes()
            .Where(type =>
                type.IsClass &&
                !type.IsAbstract &&
                type != typeof(T) &&
                type.BaseType == typeof(T))
            .ToList();

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }
    }
}