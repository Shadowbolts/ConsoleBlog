using ConsoleApp31.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BloggingDbContext context;
        protected readonly DbSet<T> dbSet;
        public Repository(BloggingDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public T? GetById(int id) => dbSet.Find(id);

        public IEnumerable<T> GetAll() => dbSet.ToList();

        public T Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }
    }
}
