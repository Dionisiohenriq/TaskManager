using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTO;

public class PersonTaskDto
{
    public PersonTaskDto(Guid id, Guid personId, string title, string description, DateTime creationDate,
        EStatus status)
    {
        Id = id;
        PersonId = personId;
        Title = title;
        Description = description;
        CreationDate = creationDate;
        Status = status;
    }

    public PersonTaskDto()
    {
    }

    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public EStatus Status { get; set; }


    public PersonTaskDto FromEntity(PersonTask entity)
    {
        PersonTaskDto personTaskDto = new PersonTaskDto(entity.Id, entity.Person.Id, entity.Title, entity.Description,
            entity.CreationDate, entity.Status);

        return personTaskDto;
    }

    public IEnumerable<PersonTaskDto> FromEntities(IEnumerable<PersonTask> personsTasks)
    {
        return personsTasks.Select(FromEntity);
    }

    public PersonTask ToEntity(PersonTaskDto personTaskDto)
    {
        PersonTask personTask = new PersonTask(personTaskDto.Title, personTaskDto.Description, personTaskDto.Status,
            personTaskDto.PersonId);

        return personTask;
    }
}