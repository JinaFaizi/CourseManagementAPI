using CourseManagement.API.DTOs.LessonDTO;

namespace CourseManagement.API.DTOs;

public class CourseResponseDto
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = string.Empty;

    public string CourseInstructor { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public CategoryResponseDto? Category { get; set; }

    public decimal CoursePrice { get; set; }

    public int CourseDuration { get; set; }

    public List<LessonResponseDto> Lessons { get; set; } = new();
}