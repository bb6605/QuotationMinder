using System.Collections.Generic;
using System.Threading.Tasks;
using QuotationMinderApi.Models;

namespace QuotationMinderApi.Data.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly ApplicationDbContext _context;

        public QuotationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quotation>> GetAllQuotationsAsync()
        {
            return await _context.Quotations.ToListAsync();
        }

        public async Task<Quotation> GetQuotationByIdAsync(int id)
        {
            return await _context.Quotations.FindAsync(id);
        }

        public async Task<Quotation> CreateQuotationAsync(Quotation quotation)
        {
            _context.Quotations.Add(quotation);
            await _context.SaveChangesAsync();
            return quotation;
        }

        public async Task<Quotation> UpdateQuotationAsync(Quotation quotation)
        {
            _context.Entry(quotation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return quotation;
        }

        public async Task DeleteQuotationAsync(int id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation != null)
            {
                _context.Quotations.Remove(quotation);
                await _context.SaveChangesAsync();
            }
        }
    }
}