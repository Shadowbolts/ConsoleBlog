using ConsoleApp31.Entity;
using DataAccessLayer.Repository.GenericRepository;

namespace DataAccess_Layer.Repos.EntityRepositoryIntefaces
{
    public interface ICommentRepository : IRepository<CommentaryEntity>
    {
        public IEnumerable<CommentaryEntity> GetCommentsByBlog(int BlogId);
    }
}
