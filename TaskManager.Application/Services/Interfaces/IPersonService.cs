using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.Interfaces;

public interface IPersonService
{
    Task<Person> AddPersonAsync(Person person);
    Task<Person> GetPersonById(Guid id);
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Person UpdatePerson(Person person);
    void SoftDelete(Guid id);
}