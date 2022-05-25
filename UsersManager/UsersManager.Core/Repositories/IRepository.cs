using System.Linq.Expressions;

namespace UsersManager.Core.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    TEntity? Get(object id);
    TEntity Create(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(object id);
}
