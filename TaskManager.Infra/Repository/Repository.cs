using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Data;

namespace TaskManager.Infra.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(AppDbContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();
    }

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        var addedEntity = await DbSet.AddAsync(entity);
        var res = SaveAsync().Result > 0 ? addedEntity.Entity : null;
        return res;
    }

    public async Task<TEntity> GetById(Guid id)
    {
        var entity = await DbSet.FindAsync(id);

        if (entity == null)
            throw new Exception("Entity not found");

        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        var result = DbSet.Update(entity).Entity;
        return entity;
    }

    public void SoftDelete(Guid id)
    {
        if (DbSet.Find(id) is not Entity entity)
            throw new KeyNotFoundException("Entity not found");

        entity.Delete();
        SaveAsync();
    }

    public async Task<int> SaveAsync()
    {
        var result = await Db.SaveChangesAsync();
        return result;
    }
}