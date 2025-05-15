using ConsoleApp31.Entity;
using ConsoleApp31.Menu;
using ConsoleApp31.Repos;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.DataBase
{
    public static class DataBaseInit
    {
        public static void DataBaseInitialization()
        {
            var options = new DbContextOptionsBuilder<BloggingDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blogging;Trusted_Connection=true");

            using (var context = new BloggingDbContext(options.Options))
            {
                context.Database.EnsureCreated();
                var blogService = new BlogService(context);
                Login login = new Login(context, blogService);
                MainMenu menu = new MainMenu(blogService, login);

                menu.Menu();
            }
        }
    }
}
