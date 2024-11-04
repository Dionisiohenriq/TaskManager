using TaskManager.Application.DTO;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Services;

public class PersonTaskService(IPersonTaskRepository personTaskRepository, PersonService personService)
    : IPersonTaskService
{
    private readonly IPersonTaskRepository _personTaskRepository = personTaskRepository;

    public Task<PersonTaskDto> AddPersonTask(PersonTaskDto personTaskDto)
    {
        try
        {
            var personTask = personTaskDto.ToEntity(personTaskDto);
            _personTaskRepository.Add(personTask);

            return Task.FromResult(personTaskDto.FromEntity(personTask));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public Task<PersonTaskDto> GetPersonTaskById(Guid id)
    {
        try
        {
            var personTask = _personTaskRepository.GetById(id).Result;

            var personTaskDto = new PersonTaskDto().FromEntity(personTask);

            return Task.FromResult(personTaskDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public Task<IEnumerable<PersonTaskDto>> GetAllPersonTasksAsync()
    {
        try
        {
            var personTasks = _personTaskRepository.GetAllAsync().Result;
            var personTaskDtos = new PersonTaskDto().FromEntities(personTasks);
            return Task.FromResult(personTaskDtos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public PersonTaskDto UpdatePersonTask(PersonTaskDto personTaskDto)
    {
        try
        {
            var personTask = _personTaskRepository.GetById(personTaskDto.Id).Result;
            _personTaskRepository.Update(personTask);
            return personTaskDto.FromEntity(personTask);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public void SoftDeletePersonTask(Guid id)
    {
        var personTaskId = _personTaskRepository.GetById(id).Result.Id;
        _personTaskRepository.SoftDelete(personTaskId);
    }
}