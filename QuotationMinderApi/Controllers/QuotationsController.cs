using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuotationMinderApi.Data.Repositories;
using QuotationMinderApi.Models;

namespace QuotationMinderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationsController(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotations()
        {
            var quotations = await _quotationRepository.GetAllAsync();
            return Ok(quotations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quotation>> GetQuotationById(int id)
        {
            var quotation = await _quotationRepository.GetByIdAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }
            return Ok(quotation);
        }

        [HttpPost]
        public async Task<ActionResult<Quotation>> CreateQuotation(Quotation quotation)
        {
            await _quotationRepository.AddAsync(quotation);
            return CreatedAtAction(nameof(GetQuotationById), new { id = quotation.Id }, quotation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuotation(int id, Quotation quotation)
        {
            if (id != quotation.Id)
            {
                return BadRequest();
            }

            await _quotationRepository.UpdateAsync(quotation);
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

            await _quotationRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}