using System.Collections;

namespace TaskManager.Domain.Interfaces;

public interface IRepository<T> : IDisposable where T : class
{
    Task<T> Add(T entity);
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    T Update(T entity);
    void SoftDelete(Guid id);
    Task<int> SaveAsync();
}