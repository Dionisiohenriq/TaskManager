using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.Interfaces;

public interface IPersonTaskService
{
    Task<PersonTask> AddPersonTask(PersonTask person);
    Task<PersonTask> GetPersonTaskById(Guid id);
    Task<IEnumerable<PersonTask>> GetAllPersonTasksAsync();
    PersonTask UpdatePersonTask(PersonTask person);
    void SoftDeletePersonTask(Guid id);
}