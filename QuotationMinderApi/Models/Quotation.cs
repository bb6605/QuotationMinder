namespace QuotationMinderApi.Models;

public class Quotation
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
     public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<QuotationAuthor> QuotationAuthors { get; set; } = new();
    public List<QuotationCategory> QuotationCategories { get; set; } = new();
}