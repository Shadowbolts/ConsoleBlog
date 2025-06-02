using BusinessLogicLayer.DataBaseContext;
using ConsoleApp31.Entity;
using DataAccessLayer.Interfaces.EntityRepositoryIntefaces;
using DataAccessLayer.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.EntityRepository
{
    public class BlogRepository : Repository<BlogEntity>, IBlogRepository
    {
        public BlogRepository(BloggingDbContext context) : base(context) { }

        public IEnumerable<BlogEntity> GetBlogsWithAuthorsAndComments()
        {
            return dbSet
                .Include(b => b.Author)
                .Include(b => b.Comments)
                .ThenInclude(c => c.User)
                .ToList();
        }
        public BlogEntity? GetBlogWithComments(int blogId)
        {
            return dbSet
                .Include(b => b.Comments)
                .FirstOrDefault(b => b.Id == blogId);
        }
    }
}
