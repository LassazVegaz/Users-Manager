using UsersManager.Core.Models;

namespace UsersManager.Core.Services;

public interface IUsersService
{
    User[] GetAllUsers();
    User[] SearchUsersByName(string username);
    User CreateUser(User user);
    User UpdateUser(int id, User user);
    bool EmailExists(string email);
    bool PhoneExists(string phone);
}
