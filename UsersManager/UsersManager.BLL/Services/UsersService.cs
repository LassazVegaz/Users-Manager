using UsersManager.Core.Models;
using UsersManager.Core.Repositories;
using UsersManager.Core.Services;

namespace UsersManager.BLL.Services;

public class UsersService : IUsersService
{

    private readonly IUsersRepository _usersRepo;


    public UsersService(IUsersRepository usersRepo)
    {
        _usersRepo = usersRepo;
    }


    public User CreateUser(User user)
    {
        user.Id = 0;
        return _usersRepo.Create(user);
    }


    public bool EmailExists(string email) =>
        _usersRepo.Search(u => u.Email == email).Any();


    public User[] SearchUsersByName(string username)
    {
        var _name = username.ToLower();
        return _usersRepo.Search(u => u.Name.ToLower().Contains(_name))
                         .ToArray();
    }


    public User[] GetAllUsers() => _usersRepo.GetAll().ToArray();


    public bool PhoneExists(string phone) =>
        _usersRepo.Search(u => u.Phone == phone).Any();


    public User UpdateUser(int id, User user)
    {
        user.Id = id;
        return _usersRepo.Update(user);
    }

}
