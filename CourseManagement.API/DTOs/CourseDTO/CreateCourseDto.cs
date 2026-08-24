namespace CourseManagement.API.DTOs;

public class CreateCourseDto
{
    public string CourseName { get; set; } = string.Empty;

    public string CourseInstructor { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public decimal CoursePrice { get; set; }

    public int CourseDuration { get; set; }
}