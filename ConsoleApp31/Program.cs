using BusinessLogic_Layer.Interfaces;
using BusinessLogic_Layer.Services;
using ConsoleApp31;
using ConsoleApp31.DataBase;
using ConsoleApp31.Menu;
using DataAccess_Layer.Repos.EntityRepositoryIntefaces;
using DataAccessLayer.Repository.EntityRepository;

static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var context = DataBaseInit.CreateContext();
        IBlogRepository blogRepository = new BlogRepository(context);
        ICommentRepository commentRepository = new CommentaryRepository(context);

        ICommentService commentService = new CommentService(commentRepository);
        IBlogService blogService = new BlogService(blogRepository);

        var login = new Login(context, blogService, commentService);
        var menu = new MainMenu(blogService, login);

        menu.Menu();
    }
}