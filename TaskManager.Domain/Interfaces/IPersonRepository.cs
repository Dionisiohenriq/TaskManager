using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<bool> VerifyPersonHasTaskAsync(Guid personId);
}