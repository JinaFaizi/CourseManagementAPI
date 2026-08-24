using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public Category Create(Category category)
    {
        return categoryRepository.Create(category);
    }

    public List<Category> GetCategories()
    {
        return categoryRepository.GetCategories();
    }

    public Category? GetById(int id)
    {
        return categoryRepository.GetById(id);
    }

    public Category? Update(int id, Category category)
    {
        return categoryRepository.Update(id, category);
    }

    public bool Delete(int id)
    {
        return categoryRepository.Delete(id);
    }
}