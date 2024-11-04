using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTO;

public class PersonTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public EStatus Status { get; set; }
}