using CourseManagement.Service.Data;
using CourseManagement.Service.Interfaces;
using CourseManagement.Service.Entities;

namespace CourseManagement.Service.Repositories;

public class SqlCategoryRepository(CourseDbContext context) : ICategoryRepository
{
    public Category Create(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();

        return category;
    }

    public List<Category> GetCategories()
    {
        return context.Categories.ToList();
    }

    public Category? GetById(int id)
    {
        return context.Categories
            .FirstOrDefault(c => c.Id == id);
    }

    public Category? Update(int id, Category category)
    {
        var existingCategory = GetById(id);

        if (existingCategory == null)
        {
            return null;
        }

        existingCategory.CategoryName = category.CategoryName;
        existingCategory.CategoryDescription = category.CategoryDescription;

        context.SaveChanges();

        return existingCategory;
    }

    public bool Delete(int id)
    {
        var category = GetById(id);

        if (category == null)
        {
            return false;
        }

        context.Categories.Remove(category);
        context.SaveChanges();

        return true;
    }
}