using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<bool> VerifyPersonExists(string email);
    Task<Person?> GetPersonByEmail(string email);
}