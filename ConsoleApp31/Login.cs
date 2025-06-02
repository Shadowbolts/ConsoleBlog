using BusinessLogicLayer.DataBaseContext;
using BusinessLogicLayer.Interfaces;
using ConsoleApp31.Menu;

namespace ConsoleApp31
{
    public class Login
    {
        private readonly BloggingDbContext _context;
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        public Login(BloggingDbContext context, IBlogService service, ICommentService commentService)
        {
            _context = context;
            _blogService = service;
            _commentService = commentService;
        }
        public void Authenticate(string password)
        {
            var user = _context.User
                .FirstOrDefault(u => u.Password == password);

            if (user != null)
            {
                BlogControllerMenu menu = new BlogControllerMenu(user.Id, _blogService, _commentService);
                menu.BlogMenu();
            }
        }
    }
}
