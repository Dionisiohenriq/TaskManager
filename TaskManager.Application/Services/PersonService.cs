using TaskManager.Application.DTO;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Services;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    private readonly IPersonRepository _personRepository = personRepository;

    public Task<PersonDto> AddPerson(PersonDto personDto)
    {
        try
        {
            if (personRepository.VerifyPersonExists(personDto.Email).Result)
            {
                var person = personDto.ToEntity(personDto);
                _personRepository.Add(person);

                return Task.FromResult(personDto.FromEntity(person));
            }

            return Task.FromResult(new PersonDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public Task<PersonDto> GetPersonById(Guid id)
    {
        try
        {
            var person = _personRepository.GetById(id).Result;

            return Task.FromResult(new PersonDto().FromEntity(person));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
    {
        try
        {
            var persons = await _personRepository.GetAllAsync();

            return new PersonDto().FromEntities(persons);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public PersonDto UpdatePerson(PersonDto personDto)
    {
        try
        {
            var person = _personRepository.GetById(personDto.Id.Value).Result;

            _personRepository.Update(personDto.ToEntity(personDto));

            return personDto.FromEntity(person);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public void SoftDelete(Guid id)
    {
        try
        {
            var person = _personRepository.GetById(id).Result;
            _personRepository.SoftDelete(person.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public Task<bool> VerifyPersonExists(string email)
    {
        try
        {
            return _personRepository.VerifyPersonExists(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }

    public Task<PersonDto?> GetPersonByEmail(string email)
    {
        try
        {
            var person = _personRepository.GetPersonByEmail(email).Result;
            return Task.FromResult(new PersonDto().FromEntity(person));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException(e.Message);
        }
    }
}