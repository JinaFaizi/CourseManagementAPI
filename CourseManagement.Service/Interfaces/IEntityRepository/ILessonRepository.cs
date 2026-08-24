using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Interfaces;

public interface ILessonRepository
{
    Lesson Create(Lesson lesson);
    List<Lesson> GetLessons();
    Lesson? GetById(int id);
    Lesson? Update(int id, Lesson lesson);
    bool Delete(int id);
    List<Lesson> GetByCourseId(int courseId);
}