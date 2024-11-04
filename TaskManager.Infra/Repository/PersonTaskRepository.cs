using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Data;

namespace TaskManager.Infra.Repository;

public class PersonTaskRepository(AppDbContext context) : Repository<PersonTask>(context), IPersonTaskRepository;