namespace QuotationMinderApi.Models;

public class QuotationAuthor
{
    public int QuotationId { get; set; }
    public Quotation Quotation { get; set; } = null!;

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}