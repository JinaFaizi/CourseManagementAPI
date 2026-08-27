using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs;

public class UpdateCourseDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string CourseName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string CourseInstructor { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal CoursePrice { get; set; }

    [Range(1, int.MaxValue)]
    public int CourseDuration { get; set; }
}