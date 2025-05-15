using ConsoleApp31.DataBase;
using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.Repos
{
    public class UserRepository : Repository<UserEntity>
    {
        public UserRepository(BloggingDbContext context) : base(context) { }

        public IEnumerable<UserEntity> GetAuthorsWithBlogs()
        {
            return dbSet.Include(a => a.Blogs).ToList();
        }
    }
}
