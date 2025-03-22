namespace QuotationMinderApi.Data.Repositories
{
    public interface IQuotationRepository
    {
        Task<IEnumerable<Quotation>> GetAllQuotationsAsync();
        Task<Quotation> GetQuotationByIdAsync(int id);
        Task<Quotation> CreateQuotationAsync(Quotation quotation);
        Task<Quotation> UpdateQuotationAsync(Quotation quotation);
        Task<bool> DeleteQuotationAsync(int id);
    }
}