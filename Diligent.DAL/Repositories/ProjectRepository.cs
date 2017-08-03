using System.Data.Entity;
using System.Linq;
using Diligent.BOL;
using Diligent.DAL.Core;

namespace Diligent.DAL.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DiligentContext context) : base(context)
        {
        }

        public Project GetProjectWithTasks(int id)
        {
            return DiligentContext.Projects.Include(p => p.Tasks).SingleOrDefault(p => p.Id == id);
        }

        public DiligentContext DiligentContext
        {
            get { return Context as DiligentContext; }
        }
    }
}
