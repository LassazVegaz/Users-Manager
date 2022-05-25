namespace UsersManager.Core.Repositories
{
    internal interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Search(Func<TEntity, bool> predicate);
        TEntity Get(object id);
        TEntity Create(TEntity entity);
        TEntity Update(object id, TEntity entity);
        void Delete(object id);
    }
}
