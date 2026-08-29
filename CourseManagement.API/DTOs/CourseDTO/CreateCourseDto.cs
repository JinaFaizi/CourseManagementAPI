using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs;

public class CreateCourseDto : IValidatableObject
{
    public string CourseName { get; set; } = string.Empty;
    
    public string CourseInstructor { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    
    public decimal CoursePrice { get; set; }
    
    public int CourseDuration { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string .IsNullOrWhiteSpace(CourseName))
        {
            yield return new ValidationResult(
                "Course name cannot be empty.",
                new[] { nameof(CourseName) });
        }
        
        else if (CourseName.Length > 100)
        {
            yield return new ValidationResult(
                "Course name cannot be more than 100 characters.",
                new[] { nameof(CourseName) });
        }
        
        else if (CourseName.Length < 3)
        {
            yield return new ValidationResult(
                "Course name must be at least 3 characters.",
                new[] { nameof(CourseName) });
        }

        if (string.IsNullOrWhiteSpace(CourseInstructor))
        {
            yield return new ValidationResult(
                "Course instructor cannot be empty.",
                new[]  { nameof(CourseInstructor) });
        }
        
        else if (CourseInstructor.Length < 3)
        {
            yield return new ValidationResult(
                "Course instructor must be at least 3 characters.",
                new[]{nameof(CourseInstructor)});
        }
        
        else if (CourseInstructor.Length > 100)
        {
            yield return new ValidationResult(
                "Course instructor cannot be more than 100 characters.",
                new[]{nameof(CourseInstructor)});
        }
        
        if (CategoryId <= 0)
        {
            yield return new ValidationResult(
                "Category id cannot be zero or negative.",
                new[]{nameof(CategoryId)});
        }

        if (CoursePrice <= 0)
        {
            yield return new ValidationResult(
                "Price cannot be zero or negative.",
                new[]{nameof(CoursePrice)});
        }

        if (CourseDuration <= 0)
        {
            yield return new ValidationResult(
                "Duration must be greater than zero.",
                new[]{nameof(CourseDuration)});
        }
    }
}