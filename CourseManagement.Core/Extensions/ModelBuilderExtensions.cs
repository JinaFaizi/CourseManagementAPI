

using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Core.Extensions;

public static class ModelBuilderExtensions
{
    public static void RegisterAllEntitiesFromAssembly<BaseType>(
        this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType) .IsAssignableFrom(c));

        foreach (Type type in types)
        {
            modelBuilder.Entity(type);
        }
    }
}
