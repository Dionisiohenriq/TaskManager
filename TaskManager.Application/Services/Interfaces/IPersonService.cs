using TaskManager.Application.DTO;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.Interfaces;

public interface IPersonService
{
    Task<PersonDto> AddPerson(PersonDto person);
    Task<PersonDto> GetPersonById(Guid id);
    Task<IEnumerable<PersonDto>> GetAllPersonsAsync();
    PersonDto UpdatePerson(PersonDto personDto);
    void SoftDelete(Guid id);
}