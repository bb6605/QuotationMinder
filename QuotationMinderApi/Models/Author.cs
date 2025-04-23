namespace QuotationMinderApi.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty; 
    public List<QuotationAuthor> QuotationAuthors { get; set; } = new();
    public List<AuthorCategory> AuthorCategories { get; set; } = new();
}