using UsersManager.Core.Models;

namespace UsersManager.Core.Services;

interface IUsersService
{
    User[] GetAllUsers();
    User[] FindUsersByName(string username);
    User CreateUser(User user);
    User UpdateUser(int id, User user);
    bool EmailExists(string email);
    bool PhoneExists(string phone);
}
