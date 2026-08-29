namespace CourseManagement.Service.Entities;

public class Course : BaseEntity
{
   
    public string CourseName { get; set; } = string.Empty;
    public string CourseInstructor { get; set; } = string.Empty;
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public decimal CoursePrice { get; set; }
    public int CourseDuration { get; set; }
    
    public List<Lesson> Lessons { get; set; } = new();
}
