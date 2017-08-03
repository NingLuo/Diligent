using System;

namespace Diligent.DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProjectRepository Projects { get; }
        void Complete();
    }
}
