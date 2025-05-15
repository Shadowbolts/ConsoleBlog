using ConsoleApp31.Configurations;
using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.DataBase
{
    public class BloggingDbContext : DbContext
    {
        public DbSet<BlogEntity> Blog { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CommentaryEntity> Commentary { get; set; }
        public BloggingDbContext(DbContextOptions<BloggingDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CommentaryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
