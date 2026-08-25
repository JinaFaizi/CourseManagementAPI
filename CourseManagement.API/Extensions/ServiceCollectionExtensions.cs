
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CourseManagement.Core.Interfaces;

namespace CourseManagement.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCourseServices(this IServiceCollection services)
    {
        var assembly = Assembly.Load("CourseManagement.Service");
        
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .ToList();

        foreach (var type in types)
        {
            
            var serviceInterface = type.GetInterfaces()
                .FirstOrDefault(i =>
                    i != typeof(IScopedDependency) &&
                    i != typeof(ITransientDependency) &&
                    i != typeof(ISingletonDependency));

            if (serviceInterface == null)
                continue;
            
            
            if (typeof(IScopedDependency).IsAssignableFrom(type))
            {
                services.AddScoped(serviceInterface, type);
            }
            
            else if (typeof(ITransientDependency).IsAssignableFrom(type))
            {
                services.AddTransient(serviceInterface, type);
            }

            else if (typeof(ISingletonDependency).IsAssignableFrom(type))
            {
                services.AddSingleton(serviceInterface, type);
            }
            
            
        }
        return services;
    }
}