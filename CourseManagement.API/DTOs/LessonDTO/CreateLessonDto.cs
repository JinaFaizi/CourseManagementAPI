using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs.LessonDTO;

public class CreateLessonDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string LessonTitle { get; set; } = string.Empty;
    
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string LessonDescription { get; set; } = string.Empty;
    
    [Range(1, int.MaxValue)]
    public int CourseId { get; set; }
}