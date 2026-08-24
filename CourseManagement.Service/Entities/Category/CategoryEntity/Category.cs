
namespace CourseManagement.Service.Entities;

public class Category : BaseEntity<int>
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
}