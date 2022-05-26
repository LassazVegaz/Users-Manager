using UsersManager.Core.Models;
using UsersManager.Core.Repositories;

namespace UsersManager.DAL.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(UsersManagerContext context) : base(context)
        {
        }
    }
}
