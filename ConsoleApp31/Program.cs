using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using ConsoleApp31;
using ConsoleApp31.DataBase;
using ConsoleApp31.Menu;
using DataAccessLayer.Interfaces.UnitOfWorkInterface;
using DataAccessLayer.Repository.EntityRepository;
using DataAccessLayer.UnitOfWork;

static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var context = DataBaseInit.CreateContext();
        IUnitOfWork unitOfWork = new UnitOfWork(context, new BlogRepository(context), new CommentaryRepository(context));

        ICommentService commentService = new CommentService(unitOfWork);
        IBlogService blogService = new BlogService(unitOfWork);

        var login = new Login(context, blogService, commentService);
        var menu = new MainMenu(blogService, login);

        menu.Menu();
    }
}