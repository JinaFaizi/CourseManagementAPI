using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Models;


namespace CourseManagemet.Service.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository courseRepository;
    
    public Course Create(Course course)
    {
        return courseRepository.Create(course);
    }

    public List<Course> GetCourses()
    {
        return courseRepository.GetCourses();
    }

    public Course? GetById(int id)
    {
        return courseRepository.GetById(id);
    }

    public Course? Update(int id, Course course)
    {
        return courseRepository.Update(id, course);
    }

    public bool Delete(int id)
    {
        return courseRepository.Delete(id);
    }
}