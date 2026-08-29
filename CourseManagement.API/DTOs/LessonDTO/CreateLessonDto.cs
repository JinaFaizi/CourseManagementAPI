using System.ComponentModel.DataAnnotations;

namespace CourseManagement.API.DTOs.LessonDTO;

public class CreateLessonDto: IValidatableObject
{
    
    public string LessonTitle { get; set; } = string.Empty;
    
    
    public string LessonDescription { get; set; } = string.Empty;
    
   
    public int CourseId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(LessonTitle))
        {
            yield return new ValidationResult(
                "Lesson title is required.",
                new[] { nameof(LessonTitle) });
        }
        else if (LessonTitle.Length < 3)
        {
            yield return new ValidationResult(
                "Lesson title must be at least 3 characters.",
                new[] { nameof(LessonTitle) });
        }
        else if (LessonTitle.Length > 50)
        {
            yield return new ValidationResult(
                "Lesson title cannot exceed 50 characters.",
                new[] { nameof(LessonTitle) });
        }

        if (string.IsNullOrWhiteSpace(LessonDescription))
        {
            yield return new ValidationResult(
                "Lesson description is required.",
                new[] { nameof(LessonDescription) });
        }
        else if (LessonDescription.Length < 3)
        {
            yield return new ValidationResult(
                "Lesson description must be at least 3 characters.",
                new[] { nameof(LessonDescription) });
        }
        else if (LessonDescription.Length > 50)
        {
            yield return new ValidationResult(
                "Lesson description cannot exceed 50 characters.",
                new[] { nameof(LessonDescription) });
        }

        if (CourseId <= 0)
        {
            yield return new ValidationResult(
                "Course ID must be greater than zero.",
                new[] { nameof(CourseId) });
        }
    }
}