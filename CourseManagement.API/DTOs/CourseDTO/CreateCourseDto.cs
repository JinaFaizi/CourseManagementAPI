using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs;

public class CreateCourseDto
{
    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string CourseName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string CourseInstructor { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    [Range(0, double.MaxValue)]
    public decimal CoursePrice { get; set; }

    [Range(1, int.MaxValue)]
    public int CourseDuration { get; set; }
}