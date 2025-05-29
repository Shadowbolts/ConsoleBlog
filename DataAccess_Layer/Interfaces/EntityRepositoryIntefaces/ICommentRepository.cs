using ConsoleApp31.Entity;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Repository.GenericRepository;

namespace DataAccessLayer.Interfaces.EntityRepositoryIntefaces
{
    public interface ICommentRepository : IRepository<CommentaryEntity>
    {
        public IEnumerable<CommentaryEntity> GetCommentsByBlog(int BlogId);
    }
}
