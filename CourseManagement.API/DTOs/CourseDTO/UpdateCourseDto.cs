using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs;

public class UpdateCourseDto : IValidatableObject
{
    public string CourseName { get; set; } = string.Empty;
    
    public string CourseInstructor { get; set; } = string.Empty;
    
    public int CategoryId { get; set; }
    
    public decimal CoursePrice { get; set; }
    
    public int CourseDuration { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(CourseName))
        {
            yield return new ValidationResult(
                "Course name is required", 
                new[] { nameof(CourseName) });
        }
        
        else if (CourseName.Length > 100)
        {
            yield return new ValidationResult(
                "Course name must be less than 100 characters",
                new[] { nameof(CourseName) });
        }
        
        else if (CourseName.Length < 2)
        {
            yield return new ValidationResult(
                "Course Name must be less than 2 characters",
                new []{nameof(CourseName)});
        }
        
        if (string.IsNullOrWhiteSpace(CourseInstructor))
        {
            yield return new ValidationResult(
                "Course name is required",
                new[] { nameof(CourseInstructor) });
        }
        
        else if (CourseInstructor.Length > 100)
        {
            yield return new ValidationResult(
                "Course name must be less than 100 characters",
                new []{nameof(CourseInstructor)});
        }
        
        else if (CourseInstructor.Length <= 3)
        {
            yield return new ValidationResult(
                "Course Instructor must be greater than 3 characters", 
                new[] { nameof(CourseInstructor) });
        }

        if (CourseDuration <= 0)
        {
            yield return new ValidationResult(
                "Course duration must be greater than zero",
                new[] { nameof(CourseDuration) });
        }

        if (CategoryId <= 0)
        {
            yield return new ValidationResult(
                "CategoryId must be greater than zero", 
                new[] { nameof(CategoryId) });
        }

        if (CoursePrice <= 0)
        {
            yield return new ValidationResult(
                "Course price must be greater than zero",
                new[] { nameof(CoursePrice) });
        }
        
    }
}