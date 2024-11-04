namespace TaskManager.Application.DTO;

public class PersonDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }

    public ICollection<PersonTaskDto> Tasks { get; set; }
}