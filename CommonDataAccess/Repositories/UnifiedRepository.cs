using Microsoft.EntityFrameworkCore;

namespace CommonDataAccess.Repositories;

public class UnifiedRepository<TEntity> : IUnifiedRepository<TEntity> where TEntity : class
{
    private readonly DbContext context;

    public UnifiedRepository(DbContext context)
    {
        this.context = context;
    }

    public bool Save()
    {
        var saved = context.SaveChanges();
        return saved > 0;
    }

    public TEntity GetById(Guid id)
    {
        return context.Set<TEntity>().Find(id);
    }

    public bool Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        return Save();
    }

    public TEntity Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        return entity;
    }

    public bool Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        return Save();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return context.Set<TEntity>().ToList();
    }
}