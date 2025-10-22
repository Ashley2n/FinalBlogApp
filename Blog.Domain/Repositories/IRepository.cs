namespace Blog.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetById(int id, CancellationToken ct = default);
    Task<List<T>> GetAll(CancellationToken ct = default);
    Task<T>AddAsync(T entity, CancellationToken ct = default);
    Task<T>UpdateAsync(T entity, CancellationToken ct = default);
    Task<T>DeleteAsync(T entity, CancellationToken ct = default);
}