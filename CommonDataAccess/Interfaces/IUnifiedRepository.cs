namespace CommonDataAccess;

public interface IUnifiedRepository<TEntity> where TEntity : class
{
    TEntity? GetById(Guid id);
    bool Add(TEntity entity);
    TEntity Update(TEntity entity);
    bool Delete(TEntity entity);
    IEnumerable<TEntity> GetAll();
}