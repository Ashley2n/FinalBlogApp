using Blog.Domain.Repositories;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    protected DbSet<T> Set => _context.Set<T>();
    
    public GenericRepository(AppDbContext db) =>  _context = db;
    
    public Task<T> GetById( int id, CancellationToken ct = default) => Set.FindAsync([id], ct).AsTask();
    
    public Task<List<T>> GetAll(CancellationToken ct = default) => Set.AsNoTracking().ToListAsync(ct);

    public async Task<T> AddAsync(T entity, CancellationToken ct = default)
    {
        Set.Add(entity);
        await _context.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken ct = default)
    {
        Set.Update(entity);
        await _context.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<T> DeleteAsync(T entity, CancellationToken ct = default)
    {
        Set.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return entity;
    }
}