using BusinessLogic_Layer.DataBaseContext;
using ConsoleApp31.DataBase;
using ConsoleApp31.Entity;
using DataAccess_Layer.Repos.EntityRepositoryIntefaces;
using DataAccessLayer.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.EntityRepository
{
    public class CommentaryRepository : Repository<CommentaryEntity>, ICommentRepository
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
