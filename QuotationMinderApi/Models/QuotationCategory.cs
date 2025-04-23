namespace QuotationMinderApi.Models;

public class QuotationCategory
{
    public int QuotationId { get; set; }
    public Quotation Quotation { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}