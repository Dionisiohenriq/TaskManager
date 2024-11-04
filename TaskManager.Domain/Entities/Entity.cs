namespace TaskManager.Domain.Entities;

public class Entity
{
    public Guid Id { get; init; }
    public bool Excluded { get; protected set; } = false;

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public void Delete()
    {
        Excluded = true;
    }
}