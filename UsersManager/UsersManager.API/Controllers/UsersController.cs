using Microsoft.AspNetCore.Mvc;
using UsersManager.Core.Models;
using UsersManager.Core.Services;

namespace UsersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;


        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [HttpGet]
        public User[] Index() => _usersService.GetAllUsers();


        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            if (_usersService.EmailExists(user.Email))
                return BadRequest("Email address already exists");
            else if (_usersService.PhoneExists(user.Phone))
                return BadRequest("Phone number already exists");

            return _usersService.CreateUser(user);
        }

        [HttpGet("isEmailAvailable/{email}")]
        public bool IsEmailAvailable(string email) => !_usersService.EmailExists(email);


        [HttpGet("isPhoneAvailable/{phone}")]
        public bool IsPhoneAvailable(string phone) => !_usersService.PhoneExists(phone);


        [HttpPut("{id:int}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User user)
        {
            if (!_usersService.UserExists(id))
                return NotFound("User is not found");

            return _usersService.UpdateUser(id, user);
        }


        [HttpGet("searchByName/{text}")]
        public User[] SearchByName(string text) => _usersService.SearchUsersByName(text);

    }
}
