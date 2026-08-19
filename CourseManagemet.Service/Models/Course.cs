namespace CourseManagemet.Service.Models;

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string CourseInstructor { get; set; } = string.Empty;
    public string CourseCategory { get; set; } = string.Empty;
    public decimal CoursePrice { get; set; }
    public int CourseDuration { get; set; }
}