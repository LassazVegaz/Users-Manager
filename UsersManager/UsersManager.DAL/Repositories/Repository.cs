using UsersManager.Core.Models;
using UsersManager.Core.Repositories;

namespace UsersManager.DAL.Repositories;

abstract class BaseRepository : IRepository<User>
{
    public User Create(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(object id)
    {
        throw new NotImplementedException();
    }

    public User Get(object id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> Search(Func<User, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public User Update(object id, User entity)
    {
        throw new NotImplementedException();
    }
}
