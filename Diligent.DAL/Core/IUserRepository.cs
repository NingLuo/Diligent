using Diligent.BOL;

namespace Diligent.DAL.Core
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithProjects(int id);
    }
}
