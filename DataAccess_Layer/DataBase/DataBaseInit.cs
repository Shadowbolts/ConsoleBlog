using BusinessLogic_Layer.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.DataBase
{
    public static class DataBaseInit
    {
        public static BloggingDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<BloggingDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blogging;Trusted_Connection=true");

            var context = new BloggingDbContext(options.Options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
