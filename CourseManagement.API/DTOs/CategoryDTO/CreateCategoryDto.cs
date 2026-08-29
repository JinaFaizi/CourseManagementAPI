using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs.CategoryDTO;

public class CreateCategoryDto : IValidatableObject
{
    public string CategoryName { get; set; } = string.Empty;
    
    public string CategoryDescription { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(CategoryName))
        {
            yield  return new ValidationResult
            ("Category name is required",
                new[] { nameof(CategoryName) });
        }

        else if (CategoryName.Length < 3)
        {
            yield return new ValidationResult(
                "Category name must be at least 2 characters.",
                new[] { nameof(CategoryName) }
            );
        }
        
        else if (CategoryName.Length > 100)
        {
            yield return new ValidationResult(
                "Category name cannot exceed 100 characters.",
                new[] { nameof(CategoryName) }
            );
        }

        if (string.IsNullOrWhiteSpace(CategoryDescription))
        {
            yield return new ValidationResult(
                "Category description is required",
                new[] { nameof(CategoryDescription) });
        }
        
        else if (CategoryDescription.Length > 100)
        {
            yield return new ValidationResult(
                "Category name cannot exceed 100 characters.",
                new[] {nameof(CategoryDescription)});
        }
        
    }
}