using CourseManagement.API.DTOs;
using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetCourses()
    {
        var courses = _courseService.GetCourses();

        return Ok(courses);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var course = _courseService.GetById(id);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public IActionResult Create(CreateCourseDto dto)
    {
        var course = new Course
        {
            CourseName = dto.CourseName,
            CourseInstructor = dto.CourseInstructor,
            CategoryId = dto.CategoryId,
            CoursePrice = dto.CoursePrice,
            CourseDuration = dto.CourseDuration
        };

        var createdCourse = _courseService.Create(course);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCourse.Id },
            createdCourse
        );
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateCourseDto dto)
    {
        var course = new Course
        {
            CourseName = dto.CourseName,
            CourseInstructor = dto.CourseInstructor,
            CategoryId = dto.CategoryId,
            CoursePrice = dto.CoursePrice,
            CourseDuration = dto.CourseDuration
        };

        var updatedCourse = _courseService.Update(id, course);

        if (updatedCourse == null)
        {
            return NotFound();
        }

        return Ok(updatedCourse);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _courseService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}