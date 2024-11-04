using TaskManager.Domain.Entities;

namespace TaskManager.Application.DTO;

public class PersonDto
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }

    public PersonDto()
    {
    }

    public PersonDto(Guid? id, string? name, string? email, DateTime birthDate)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
    }

    public PersonDto FromEntity(Person person)
    {
        return new PersonDto(person.Id, person.Name, person.Email, person.BirthDate);
    }

    public Person ToEntity(PersonDto personDto)
    {
        return new Person(personDto.Name, personDto.Email, personDto.BirthDate, personDto.Password);
    }

    public IEnumerable<PersonDto> FromEntities(IEnumerable<Person> persons)
    {
        return persons.Select(FromEntity);
    }
}