using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs.LessonDTO;

public class UpdateLessonDto : IValidatableObject
{
    public string LessonTitle { get; set; } = string.Empty;
    
    public string LessonDescription { get; set; } = string.Empty;
    
    public int CourseId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(LessonTitle))
        {
            yield return new ValidationResult(
                "LessonTitle cannot be empty",
                new[] { nameof(LessonTitle) });
        }
        
        else if (LessonTitle.Length < 5)
        {
            yield return new ValidationResult(
                "LessonTitle cannot be less than 5",
                new[] { nameof(LessonTitle) });
        }
        
        else if (LessonTitle.Length > 100)
        {
            yield return new ValidationResult(
                "LessonTitle cannot be more than 100",
                new[] { LessonTitle });
        }

        if (string.IsNullOrWhiteSpace(LessonDescription))
        {
            yield return new ValidationResult(
                "LessonDescription cannot be empty",
                new[] { nameof(LessonDescription) });
        }
        
        else if (LessonDescription.Length > 1000)
        {
            yield return new ValidationResult(
                "LessonDescription cannot be more than 1000 characters",
                new[] { nameof(LessonDescription) });
        }
        
        else if (LessonDescription.Length < 1)
        {
            yield return new ValidationResult(
                "LessonDescription cannot be less than 1",
                new[] { nameof(LessonDescription) });
        }

        if (CourseId < 0)
        {
            yield return new ValidationResult(
                "CourseId cannot be less than 0",
                new[] { nameof(CourseId) });
        }
    }
}