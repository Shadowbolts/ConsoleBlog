using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using ConsoleApp31.Enums;
using ConsoleApp31.Menu.BlogControllerSubMenus;

namespace ConsoleApp31.Menu
{
    public class BlogControllerMenu
    {
        private readonly int _id;
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;

        public BlogControllerMenu(int id, IBlogService blogService, ICommentService commentService)
        {
            _id = id;
            _blogService = blogService;
            _commentService = commentService;
        }
        public void BlogMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Керування блогами\n2. Керування коментарями\n9. Вихід");
                if (Enum.TryParse(Console.ReadLine(), out BlogMenuControllerOptions choice))
                {
                    switch (choice)
                    {
                        case BlogMenuControllerOptions.Blog:
                            {
                                BlogCRUDMenu blogMenu = new BlogCRUDMenu(_id, _blogService);
                                blogMenu.BlogMenu();
                                break;
                            }
                        case BlogMenuControllerOptions.Commentary:
                            {
                                CommentaryCRUDMenu commentMenu = new CommentaryCRUDMenu(_id, _blogService, _commentService);
                                commentMenu.CommentMenu();
                                break;
                            }
                        case BlogMenuControllerOptions.Exit:
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Невідома опція");
                                break;
                            }
                    }
                }
            }
        }
    }
}
