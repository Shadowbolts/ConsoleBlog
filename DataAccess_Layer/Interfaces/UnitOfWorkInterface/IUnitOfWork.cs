using DataAccessLayer.Interfaces.EntityRepositoryIntefaces;

namespace DataAccessLayer.Interfaces.UnitOfWorkInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        ICommentRepository Comments { get; }

        int SaveChanges();
    }
}
