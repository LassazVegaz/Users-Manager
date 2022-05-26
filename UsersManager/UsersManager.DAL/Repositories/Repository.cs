using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UsersManager.Core.Repositories;

namespace UsersManager.DAL.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{

    protected readonly UsersManagerContext context;


    protected BaseRepository(UsersManagerContext context)
    {
        this.context = context;
    }


    public TEntity Create(TEntity entity)
    {
        var newUser = context.Add(entity).Entity;
        context.SaveChanges();
        return newUser;
    }

    public void Delete(object id)
    {
        var user = context.Find<TEntity>(id);
        if (user == null)
            throw new Exception($"User with ${id} is not found");

        context.Remove(user);
        context.SaveChanges();
    }

    public TEntity? Get(object id)
    {
        var entity = context.Find<TEntity>(id);

        if (entity != null)
            context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return context.Set<TEntity>().AsNoTracking();
    }

    public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Where(predicate).AsNoTracking();
    }

    public TEntity Update(TEntity entity)
    {
        var updatedEntity = context.Update(entity);
        context.SaveChanges();
        return updatedEntity.Entity;
    }

}
