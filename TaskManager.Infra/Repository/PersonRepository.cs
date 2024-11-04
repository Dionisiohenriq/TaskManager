using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Data;

namespace TaskManager.Infra.Repository;

public class PersonRepository(AppDbContext context) : Repository<Person>(context), IPersonRepository
{
    public async Task<bool> VerifyPersonExists(string email)
    {
        var person = await DbSet.Where(p => p.Email.Equals(email)).FirstOrDefaultAsync();
        return person is not null;
    }

    public async Task<Person?> GetPersonByEmail(string email)
    {
        var person = await DbSet.Where(p => p.Email.Equals(email)).FirstOrDefaultAsync();
        return person;
    }
}