using IkeaShop.Order.Data;
using IkeaShop.Order.Interfaces;

namespace IkeaShop.Order.Repositories;

// using IkeaShop.Order.Data;
// using IkeaShop.Order.Interfaces;
// using IkeaShop.Order.Models;;

public class UnifiedRepository<TEntity> : IUnifiedRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDatabaseContext context;

    public UnifiedRepository(ApplicationDatabaseContext context)
    {
        this.context = context;
    }

    public bool Save()
    {
        var saved = context.SaveChanges();
        return saved > 0;
    }

    public TEntity GetById(int id)
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