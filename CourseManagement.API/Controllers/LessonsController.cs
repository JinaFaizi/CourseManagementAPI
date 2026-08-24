using CourseManagement.API.DTOs;
using CourseManagement.API.DTOs.LessonDTO;
using CourseManagement.Service.Entities;
using CourseManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    public IActionResult GetLessons()
    {
        var lessons = _lessonService.GetLessons();

        return Ok(lessons);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var lesson = _lessonService.GetById(id);

        if (lesson == null)
        {
            return NotFound();
        }

        return Ok(lesson);
    }

    [HttpGet("course/{courseId}")]
    public IActionResult GetByCourseId(int courseId)
    {
        var lessons = _lessonService.GetByCourseId(courseId);

        return Ok(lessons);
    }

    [HttpPost]
    public IActionResult Create(CreateLessonDto dto)
    {
        var lesson = new Lesson
        {
            LessonTitle = dto.LessonTitle,
            LessonDescription = dto.LessonDescription,
            CourseId = dto.CourseId
        };

        var createdLesson = _lessonService.Create(lesson);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdLesson.Id },
            createdLesson
        );
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateLessonDto dto)
    {
        var lesson = new Lesson
        {
            LessonTitle = dto.LessonTitle,
            LessonDescription = dto.LessonDescription,
            CourseId = dto.CourseId
        };

        var updatedLesson = _lessonService.Update(id, lesson);

        if (updatedLesson == null)
        {
            return NotFound();
        }

        return Ok(updatedLesson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _lessonService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}

