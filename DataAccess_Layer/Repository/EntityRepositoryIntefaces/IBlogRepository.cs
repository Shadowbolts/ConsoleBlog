using ConsoleApp31.Entity;
using DataAccessLayer.Repository.GenericRepository;

namespace DataAccess_Layer.Repos.EntityRepositoryIntefaces
{
    public interface IBlogRepository  : IRepository<BlogEntity>
    {
        IEnumerable<BlogEntity> GetBlogsWithAuthorsAndComments();
        BlogEntity? GetBlogWithComments(int blogId);
    }
}
