using ConsoleApp31.Entity;
using DataAccessLayer.Repository.GenericRepository;

namespace DataAccessLayer.Interfaces.EntityRepositoryIntefaces
{
    public interface IBlogRepository : IRepository<BlogEntity>
    {
        IEnumerable<BlogEntity> GetBlogsWithAuthorsAndComments();
        BlogEntity? GetBlogWithComments(int blogId);
    }
}
