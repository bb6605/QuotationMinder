using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using QuotationMinderApi.Data;

namespace QuotationMinderApi.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly QuotationMinderDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(QuotationMinderDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetWithIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes == null || includes.Length == 0)
        {
            return await query.ToListAsync();
        }

        foreach (var include in includes)
        {
            if (include == null)
            {
                throw new ArgumentException("Include expression cannot be null.", nameof(includes));
            }

            query = query.Include(include);
        }

        return await query.ToListAsync();
    }
}