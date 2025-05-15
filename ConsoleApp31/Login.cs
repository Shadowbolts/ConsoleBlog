using ConsoleApp31.DataBase;
using ConsoleApp31.Entity;
using ConsoleApp31.Menu;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31
{
    public class Login
    {
        private readonly BloggingDbContext _context;
        private readonly BlogService _service;
        public Login(BloggingDbContext context, BlogService service)
        {
            _context = context;
            _service = service;
        }
        public void Authenticate(string password)
        {
            var user = _context.User
                .FirstOrDefault(u => u.Password == password);

            if (user != null)
            {
                BlogControllerMenu menu = new BlogControllerMenu(user.Id, _service);
                menu.BlogMenu();
            }
        }
    }
}
