using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs.CategoryDTO;

public class CreateCategoryDto
{
    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string CategoryName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string CategoryDescription { get; set; } = string.Empty;
}