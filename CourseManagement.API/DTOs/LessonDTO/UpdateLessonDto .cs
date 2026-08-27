using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs.LessonDTO;

public class UpdateLessonDto
{
    [Required]
    [MaxLength(50)]
    [MinLength(5)]
    public string LessonTitle { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(1000)]
    [MinLength(5)]
    public string LessonDescription { get; set; } = string.Empty;
    
    [Range(1, int.MaxValue)]
    public int CourseId { get; set; }
}