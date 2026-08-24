namespace CourseManagement.Service.Entities;

public class Lesson : BaseEntity<int>
{
    public string LessonTitle { get; set; } = string.Empty;
    public string LessonDescription { get; set; } = string.Empty;
    public int CourseId { get; set; }
}