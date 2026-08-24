using CourseManagement.Service.Entities;
using CourseManagement.Service.Interfaces;


namespace CourseManagement.Service.Repositories;

public class InMemoryCourseRepository : ICourseRepository
{
    private readonly List<Course> courses = new();

    public Course Create(Course course)
    {
        course.Id = courses.Count + 1;
        courses.Add(course);
        return course;
    }

    public List<Course> GetCourses()
    {
        return courses;
    }

    public Course? GetById(int id)
    {
        return courses.FirstOrDefault(c => c.Id == id);
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
        existingCourse.Category = course.Category;
        existingCourse.CoursePrice = course.CoursePrice;
        existingCourse.CourseDuration = course.CourseDuration;
        
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

