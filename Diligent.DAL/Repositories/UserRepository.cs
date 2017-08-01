using System.Data.Entity;
using System.Linq;
using Diligent.BOL;
using Diligent.DAL.Core;

namespace Diligent.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DiligentContext context) : base(context)
        {           
        }
        
        public User GetUserWithProjects(int id)
        {
            return DiligentContext.Users.Include(u => u.Projects).SingleOrDefault(u => u.Id == id);
        }

        public DiligentContext DiligentContext
        {
            get { return Context as DiligentContext; }
        }
    }
}
