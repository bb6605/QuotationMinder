using QuotationMinderApi.Models;

namespace QuotationMinderApi.Data;

public static class QuotationMinderDbSeeder
{
    public static void Seed(QuotationMinderDbContext context)
    {
        if (!context.Authors.Any())
        {
            context.Authors.AddRange(
                new Author { Name = "Author 1" },
                new Author { Name = "Author 2" }
            );
        }

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Name = "Category 1" },
                new Category { Name = "Category 2" }
            );
        }

        if (!context.Quotations.Any())
        {
            context.Quotations.AddRange(
                new Quotation { Text = "Quotation 1" },
                new Quotation { Text = "Quotation 2" }
            );
        }

        context.SaveChanges();
    }
}