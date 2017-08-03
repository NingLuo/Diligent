using System.Collections.Generic;
using System.Linq;
using Diligent.BOL;
using Diligent.DAL;

namespace Diligent.BLL
{
    public class ProjectBs : BLLBase
    {
        private UnitOfWork _unitOfWork;

        public ProjectBs(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Project> GetByUserId(int id)
        {
            return _unitOfWork.Projects.Find(p => p.UserId == id).ToList();
        }

        public bool CreateProject(Project project)
        {
            if (!IsValidOnCreate(project)) return false;

            _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();

            return true;
        }

        private bool IsValidOnCreate(Project project)
        {
            return true;
        }
    }
}
