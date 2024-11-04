using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Services;

public class PersonTaskService(IPersonTaskRepository personTaskRepository, PersonService personService)
    : IPersonTaskService
{
    private readonly IPersonTaskRepository _personTaskRepository = personTaskRepository;
    private readonly PersonService _personService = personService;

    public Task<PersonTask> AddPersonTask(PersonTask person)
    {
        throw new NotImplementedException();
    }

    public Task<PersonTask> GetPersonTaskById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PersonTask>> GetAllPersonTasksAsync()
    {
        throw new NotImplementedException();
    }

    public PersonTask UpdatePersonTask(PersonTask person)
    {
        throw new NotImplementedException();
    }

    public void SoftDeletePersonTask(Guid id)
    {
        throw new NotImplementedException();
    }
}