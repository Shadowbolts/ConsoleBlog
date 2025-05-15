using ConsoleApp31.DataBase;
using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.Repos
{
    public class BlogRepository : Repository<BlogEntity>
    {
        private readonly BloggingDbContext _context;
        public BlogRepository(BloggingDbContext context) : base(context) 
        {
            _context = context;
        }

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
