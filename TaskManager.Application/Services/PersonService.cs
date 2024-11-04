using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Services;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    private readonly IPersonRepository _personRepository = personRepository;

    public Task<Person> AddPersonAsync(Person person)
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetPersonById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        throw new NotImplementedException();
    }

    public Person UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void SoftDelete(Guid id)
    {
        throw new NotImplementedException();
    }
}