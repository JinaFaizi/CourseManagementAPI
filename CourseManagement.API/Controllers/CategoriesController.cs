
using CourseManagement.API.DTOs;
using CourseManagement.API.DTOs.CategoryDTO;
using CourseManagement.Service.Entities;
using CourseManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CourseManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _categoryService.GetCategories();

        return Ok(categories.Select(MapToDto));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetById(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName,
            CategoryDescription = dto.CategoryDescription
        };

        var createdCategory = _categoryService.Create(category);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCategory.Id },
            createdCategory
        );
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateCategoryDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName,
            CategoryDescription = dto.CategoryDescription
        };

        var updatedCategory = _categoryService.Update(id, category);

        if (updatedCategory == null)
        {
            return NotFound();
        }

        return Ok(MapToDto(updatedCategory));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _categoryService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    private static CategoryResponseDto MapToDto(Category category)
    {
        return new CategoryResponseDto
        {
            CategoryId = category.Id,
            CategoryName = category.CategoryName,
            CategoryDescription = category.CategoryDescription
        };
    }
}