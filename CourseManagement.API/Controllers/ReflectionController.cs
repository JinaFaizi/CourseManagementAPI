using CourseManagement.Service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReflectionController : ControllerBase
{
    [HttpGet("classes")]
    public IActionResult GetClasses()
    {
        var assembly = typeof(Course).Assembly;

        var types = assembly.GetTypes();

        var classNames = types
            .Where(t => t.IsClass)
            .Select(t => t.Name)
            .ToList();

        return Ok(classNames);
        
    }
    
    
    [HttpGet("entities")]
    public IActionResult GetEntities()
    {
        var assembly = typeof(Course).Assembly;

        var entityNames = assembly
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.Namespace == "CourseManagement.Service.Entities")
            .Select(t => t.Name)
            .ToList();

        return Ok(entityNames);
    }
}