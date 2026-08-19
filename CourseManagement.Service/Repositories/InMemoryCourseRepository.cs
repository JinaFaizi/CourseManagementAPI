using CourseManagement.Service.Models;
using CourseManagement.Service.Interfaces;


namespace CourseManagement.Service.Repositories;

public class InMemoryCourseRepository : ICourseRepository
{
    private readonly List<Course> courses = new();
    public Course Create(Course course)
    {
        Course.CourseId = courses.Count + 1;
        courses.Add(course);
        return course;
    }

    public List<Course> GetCourses()
    {
        return courses;
    }

    public Course? GetById(int id)
    {
        return courses.FirstOrDefault(c => c.CourseId == id);
    }

    public Course? Update(int id, string courseName)
    {
        var existingCourse = GetById(id);

        if (existingCourse == null)
        {
            return null;
        }
        
        existingCourse.CourseName = Course.CourseName;
        existingCourse.CourseInstructor = Course.CourseInstructor;
        existingCourse.CourseCategory = Course.CourseCategory;
        existingCourse.CoursePrice = Course.CoursePrice;
        existingCourse.CourseDuration = Course.CourseDuration;
        
        return existingCourse;
    }

    public bool Delete(int id)
    {
        var course = GetById(id);
        if (course == null)
        {
            return false;
        }
        
        courses.Remove(course);
        return true;
    }
}