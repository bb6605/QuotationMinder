using Microsoft.AspNetCore.Mvc;
using QuotationMinderApi.Models;
using QuotationMinderApi.Repositories;

namespace QuotationMinderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryController(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        await _categoryRepository.AddAsync(category);
        return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(id);
        if (existingCategory == null) return NotFound();

        existingCategory.Name = category.Name;
        await _categoryRepository.UpdateAsync(existingCategory);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) return NotFound();

        await _categoryRepository.DeleteAsync(category);
        return NoContent();
    }

    [HttpGet("debug/db")]
    public async Task<IActionResult> GetDatabaseContents()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return Ok(new { Categories = categories });
    }
}