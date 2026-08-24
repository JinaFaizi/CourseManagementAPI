namespace CourseManagement.API.DTOs.LessonDTO;

public class LessonResponseDto
{
    public int LessonId { get; set; }
    public string LessonTitle { get; set; } = string.Empty;
    public string LessonDescription { get; set; } = string.Empty;
    public int CourseId { get; set; }
}