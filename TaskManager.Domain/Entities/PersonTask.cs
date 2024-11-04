using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class PersonTask : Entity
{
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreationDate { get; init; }
    public EStatus Status { get; set; }
    public Person Person { get; set; }

    public PersonTask(string title, string? description)
    {
        SetTitle(title);
        SetDescription(description);
        CreationDate = DateTime.Now;
        Status = EStatus.Pending;
    }

    public void SetTitle(string? title)
    {
        if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
        Title = title;
    }

    public void SetDescription(string? description)
    {
        if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
        Description = description;
    }

    public void SetTaskInProgress()
    {
        Status = EStatus.InProgress;
    }

    public void SetTaskCompleted()
    {
        Status = EStatus.Completed;
    }
}