using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Service.Entities;

public class Lesson : BaseEntity
{
    public string LessonTitle { get; set; } 
    public string LessonDescription { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
public class LessonConfiguration:IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(p=>p.LessonTitle).HasDefaultValue("");
        builder.Property(p => p.LessonDescription).HasMaxLength(50);
        builder.HasOne(p=>p.Course).WithMany(p=>p.Lessons).HasForeignKey(p=>p.CourseId);
    }
}