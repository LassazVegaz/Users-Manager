using UsersManager.Core.Models;

namespace UsersManager.DAL.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository(UsersManagerContext context) : base(context)
        {
        }
    }
}
