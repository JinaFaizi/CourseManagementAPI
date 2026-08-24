using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Interfaces;

public interface ICategoryService
{
    Category Create(Category category);
    List<Category> GetCategories();
    Category? GetById(int id);
    Category? Update(int id, Category category);
    bool Delete(int id);
}