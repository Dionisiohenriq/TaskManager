using TaskManager.Application.DTO;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.Interfaces;

public interface IPersonTaskService
{
    Task<PersonTaskDto> AddPersonTask(PersonTaskDto personTaskDto);
    Task<PersonTaskDto> GetPersonTaskById(Guid id);
    Task<IEnumerable<PersonTaskDto>> GetAllPersonTasksAsync();
    PersonTaskDto UpdatePersonTask(PersonTaskDto personTaskDto);
    void SoftDeletePersonTask(Guid id);
}