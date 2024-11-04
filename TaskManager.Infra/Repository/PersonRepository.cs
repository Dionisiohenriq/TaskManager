using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Data;

namespace TaskManager.Infra.Repository;

public class PersonRepository(AppDbContext context) : Repository<Person>(context), IPersonRepository
{
    public async Task<bool> VerifyPersonHasTaskAsync(Guid personId)
    {
        var person = await DbSet.FindAsync(personId);
        if (person is null)
            return false;

        var hasTask = person.Tasks.Count != 0;

        return hasTask;
    }
}