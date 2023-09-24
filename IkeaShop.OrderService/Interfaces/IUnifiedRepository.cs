namespace IkeaShop.Order.Interfaces;

public interface IUnifiedRepository<TEntity> where TEntity : class
{
    TEntity GetById(int id);
    bool Add(TEntity entity);
    TEntity Update(TEntity entity);
    bool Delete(TEntity entity);
    IEnumerable<TEntity> GetAll();
}