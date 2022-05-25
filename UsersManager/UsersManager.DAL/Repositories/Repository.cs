using UsersManager.Core.Models;
using UsersManager.Core.Repositories;

namespace UsersManager.DAL.Repositories;

abstract class BaseRepository : IRepository<User>
{

    private readonly UsersManagerContext context;


    protected BaseRepository(UsersManagerContext context)
    {
        this.context = context;
    }


    public User Create(User entity)
    {
        var newUser = context.Users.Add(entity).Entity;
        context.SaveChanges();
        return newUser;
    }

    public void Delete(object id)
    {
        var user = context.Users.Find(id);
        if (user == null)
            throw new Exception($"User with ${id} is not found");

        context.Users.Remove(user);
        context.SaveChanges();
    }

    public User? Get(object id)
    {
        return context.Users.Find(id);
    }

    public IQueryable<User> GetAll()
    {
        return context.Users;
    }

    public IQueryable<User> Search(Func<User, bool> predicate)
    {
        return context.Users.Where(predicate).AsQueryable();
    }

    public User Update(object id, User entity)
    {
        var user = context.Users.Find(id);
        if (user == null)
            throw new Exception($"User with ${id} is not found");

        user.Address = entity.Address;
        user.Name = entity.Name;
        user.Estimate = entity.Estimate;
        user.Email = entity.Email;
        user.Phone = entity.Phone;

        context.SaveChanges();

        return user;
    }
}
