using Diligent.DAL.Core;
using Diligent.DAL.Repositories;

namespace Diligent.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiligentContext _context;
        public UnitOfWork(DiligentContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Projects = new ProjectRepository(_context);
        }

        public IProjectRepository Projects { get; private set; }
        public IUserRepository Users { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
