using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Interfaces;

public interface ILessonService
{
    Lesson Create(Lesson lesson);
    List<Lesson> GetLessons();
    Lesson? GetById(int id);
    List<Lesson> GetByCourseId(int courseId);
    Lesson? Update(int id, Lesson lesson);
    bool Delete(int id);
}