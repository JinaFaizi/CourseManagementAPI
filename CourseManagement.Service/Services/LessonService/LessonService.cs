using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Services;

public class LessonService(ILessonRepository lessonRepository) : ILessonService
{
    public Lesson Create(Lesson lesson)
    {
        return lessonRepository.Create(lesson);
    }

    public List<Lesson> GetLessons()
    {
        return lessonRepository.GetLessons();
    }

    public Lesson? GetById(int id)
    {
        return lessonRepository.GetById(id);
    }

    public Lesson? Update(int id, Lesson lesson)
    {
        return lessonRepository.Update(id, lesson);
    }

    public bool Delete(int id)
    {
        return lessonRepository.Delete(id);
    }
    public List<Lesson> GetByCourseId(int courseId)
    {
        return lessonRepository.GetByCourseId(courseId);
    }
}