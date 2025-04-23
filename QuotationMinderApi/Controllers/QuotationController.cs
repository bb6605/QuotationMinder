using Microsoft.AspNetCore.Mvc;
using QuotationMinderApi.Models;
using QuotationMinderApi.Repositories;

namespace QuotationMinderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotationController : ControllerBase
{
    private readonly IRepository<Quotation> _quotationRepository;

    public QuotationController(IRepository<Quotation> repository)
    {
        _quotationRepository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuotations()
    {
        // Fetch all quotations from the repository
        var quotations =await _quotationRepository.GetWithIncludesAsync(
            q => q.QuotationAuthors,
            q => q.QuotationCategories
        );
        return Ok(quotations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuotationById(int id)
    {
        var quotation = await _quotationRepository.GetByIdAsync(id);
        if (quotation == null) return NotFound();
        return Ok(quotation);
    }

    [HttpPost]
    public async Task<IActionResult> AddQuotation([FromBody] Quotation newQuotation)
    {
        if (newQuotation == null)
        {
            return BadRequest("Quotation cannot be null.");
        }

        await _quotationRepository.AddAsync(newQuotation);
        return CreatedAtAction(nameof(GetQuotationById), new { id = newQuotation.Id }, newQuotation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuotation(int id, [FromBody] Quotation updatedQuotation)
    {
        if (id != updatedQuotation.Id)
        {
            return BadRequest("Quotation ID mismatch.");
        }

        var existingQuotation = await _quotationRepository.GetByIdAsync(id);
        if (existingQuotation == null)
        {
            return NotFound();
        }

        await _quotationRepository.UpdateAsync(updatedQuotation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuotation(int id)
    {
        var quotation = await _quotationRepository.GetByIdAsync(id);
        if (quotation == null)
        {
            return NotFound();
        }

        await _quotationRepository.DeleteAsync(quotation);
        return NoContent();
    }

    [HttpGet("debug/db")]
    public async Task<IActionResult> GetDatabaseContents()
    {
        var quotations = await _quotationRepository.GetAllAsync();
        return Ok(new { Quotations = quotations });
    }
}