using CourseManagement.Service.Models;

namespace CourseManagement.Service.Interfaces;

public interface ICourseService
{
    Course Create(Course course);
    List<Course> GetCourses();
    Course? GetById(int id);
    Course? Update(int id, Course course);
    bool Delete(int id);
}