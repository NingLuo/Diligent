using Diligent.BOL;

namespace Diligent.DAL.Core
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetProjectWithTasks(int id);
    }
}
