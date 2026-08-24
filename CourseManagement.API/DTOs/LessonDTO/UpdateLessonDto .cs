namespace CourseManagement.API.DTOs.LessonDTO;

public class UpdateLessonDto_
{
    public string LessonTitle { get; set; } = string.Empty;
    public string LessonDescription { get; set; } = string.Empty;
    public int CourseId { get; set; }
}