using Microsoft.EntityFrameworkCore;
using QuotationMinderApi.Models;

namespace QuotationMinderApi.Data;

public class QuotationMinderDbContext : DbContext
{
    public QuotationMinderDbContext(DbContextOptions<QuotationMinderDbContext> options) : base(options) { }

    public DbSet<Quotation> Quotations { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<QuotationAuthor> QuotationAuthors { get; set; } = null!;
    public DbSet<QuotationCategory> QuotationCategories { get; set; } = null!;
    public DbSet<AuthorCategory> AuthorCategories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<QuotationAuthor>().HasKey(qa => new { qa.QuotationId, qa.AuthorId });
        modelBuilder.Entity<QuotationCategory>().HasKey(qc => new { qc.QuotationId, qc.CategoryId });
        modelBuilder.Entity<AuthorCategory>().HasKey(ac => new { ac.AuthorId, ac.CategoryId });

        modelBuilder.Entity<QuotationAuthor>()
            .HasOne(qa => qa.Quotation)
            .WithMany(q => q.QuotationAuthors)
            .HasForeignKey(qa => qa.QuotationId);

        modelBuilder.Entity<QuotationAuthor>()
            .HasOne(qa => qa.Author)
            .WithMany(a => a.QuotationAuthors)
            .HasForeignKey(qa => qa.AuthorId);

        modelBuilder.Entity<QuotationCategory>()
            .HasOne(qc => qc.Quotation)
            .WithMany(q => q.QuotationCategories)
            .HasForeignKey(qc => qc.QuotationId);

        modelBuilder.Entity<QuotationCategory>()
            .HasOne(qc => qc.Category)
            .WithMany(c => c.QuotationCategories)
            .HasForeignKey(qc => qc.CategoryId);

        modelBuilder.Entity<AuthorCategory>()
            .HasOne(ac => ac.Author)
            .WithMany(a => a.AuthorCategories)
            .HasForeignKey(ac => ac.AuthorId);

        modelBuilder.Entity<AuthorCategory>()
            .HasOne(ac => ac.Category)
            .WithMany(c => c.AuthorCategories)
            .HasForeignKey(ac => ac.CategoryId);
    }
}