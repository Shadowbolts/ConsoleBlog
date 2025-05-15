using ConsoleApp31.DataBase;
using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.Repos
{
    public class CommentaryRepository : Repository<CommentaryEntity>
    {
        public CommentaryRepository(BloggingDbContext context) : base(context) { }

        public IEnumerable<CommentaryEntity> GetCommentsByBlog(int BlogId)
        {
            return dbSet.Where(c => c.BlogId == BlogId)
                .Include(c => c.User)
                .ToList();
        }
    }
}
