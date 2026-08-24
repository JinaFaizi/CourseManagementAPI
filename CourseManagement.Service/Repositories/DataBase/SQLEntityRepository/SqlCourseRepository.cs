using CourseManagement.Service.Data;
using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Repositories;

public class SqlCourseRepository(CourseDbContext context) : ICourseRepository
{
    public Course Create(Course course)
    {
        context.Courses.Add(course);
        context.SaveChanges();

        return course;
    }

    public List<Course> GetCourses()
    {
        return context.Courses.ToList();
    }

    public Course? GetById(int id)
    {
        return context.Courses
            .FirstOrDefault(c => c.Id == id);
    }

    public Course? Update(int id, Course course)
    {
        var existingCourse = GetById(id);

        if (existingCourse == null)
        {
            return null;
        }

        existingCourse.CourseName = course.CourseName;
        existingCourse.CourseInstructor = course.CourseInstructor;
        existingCourse.CategoryId = course.CategoryId;
        existingCourse.CoursePrice = course.CoursePrice;
        existingCourse.CourseDuration = course.CourseDuration;

        context.SaveChanges();

        return existingCourse;
    }

    public bool Delete(int id)
    {
        var course = GetById(id);

        if (course == null)
        {
            return false;
        }

        context.Courses.Remove(course);
        context.SaveChanges();

        return true;
    }
}