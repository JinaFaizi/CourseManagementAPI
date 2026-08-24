using CourseManagement.Service.Data;
using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Repositories;

public class SqlLessonRepository(CourseDbContext context) : ILessonRepository
{
    public Lesson Create(Lesson lesson)
    {
        context.Lessons.Add(lesson);
        context.SaveChanges();

        return lesson;
    }

    public List<Lesson> GetLessons()
    {
        return context.Lessons.ToList();
    }

    public Lesson? GetById(int id)
    {
        return context.Lessons
            .FirstOrDefault(l => l.Id == id);
    }

    public Lesson? Update(int id, Lesson lesson)
    {
        var existingLesson = GetById(id);

        if (existingLesson == null)
        {
            return null;
        }

        existingLesson.LessonTitle = lesson.LessonTitle;
        existingLesson.LessonDescription = lesson.LessonDescription;
        existingLesson.CourseId = lesson.CourseId;

        context.SaveChanges();

        return existingLesson;
    }

    public bool Delete(int id)
    {
        var lesson = GetById(id);

        if (lesson == null)
        {
            return false;
        }

        context.Lessons.Remove(lesson);
        context.SaveChanges();

        return true;
    }
    
    public List<Lesson> GetByCourseId(int courseId)
    {
        return context.Lessons
            .Where(l => l.CourseId == courseId)
            .ToList();
    }
}