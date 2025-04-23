using Microsoft.AspNetCore.Mvc;
using QuotationMinderApi.Models;
using QuotationMinderApi.Repositories;

namespace QuotationMinderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IRepository<Author> _authorRepository;

    public AuthorController(IRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _authorRepository.GetAllAsync();
        return Ok(authors);
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] Author author)
    {
        if (author == null)
        {
            return BadRequest("Author cannot be null.");
        }

        await _authorRepository.AddAsync(author);
        return CreatedAtAction(nameof(GetAllAuthors), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author updatedAuthor)
    {
        if (updatedAuthor == null || id != updatedAuthor.Id)
        {
            return BadRequest("Invalid author data.");
        }

        var existingAuthor = await _authorRepository.GetByIdAsync(id);
        if (existingAuthor == null)
        {
            return NotFound();
        }

        existingAuthor.Name = updatedAuthor.Name;
        existingAuthor.Biography = updatedAuthor.Biography;
        // Update other properties as needed

        await _authorRepository.UpdateAsync(existingAuthor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        await _authorRepository.DeleteAsync(author);
        return NoContent();
    }
}