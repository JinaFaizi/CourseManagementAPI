using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Repositories;
using CourseManagement.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CourseManagement.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCourseServices(this IServiceCollection services)
    {
        
        services.AddScoped<ICourseRepository, SqlCourseRepository>();
        services.AddScoped<ICategoryRepository, SqlCategoryRepository>();
        services.AddScoped<ILessonRepository, SqlLessonRepository>();
        
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ILessonService, LessonService>();

        return services;
    }
}