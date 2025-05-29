using BusinessLogic_Layer.DataBaseContext;
using DataAccessLayer.Interfaces.EntityRepositoryIntefaces;
using DataAccessLayer.Interfaces.UnitOfWorkInterface;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloggingDbContext _dbContext;
        public IBlogRepository Blogs { get; }

        public ICommentRepository Comments { get; }
        public UnitOfWork(BloggingDbContext dbContext, IBlogRepository blogs, ICommentRepository comments)
        {
            _dbContext = dbContext;
            Blogs = blogs;
            Comments = comments;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public int SaveChanges() => _dbContext.SaveChanges();
    }
}
