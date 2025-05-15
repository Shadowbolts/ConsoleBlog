using ConsoleApp31.DataBase;
using ConsoleApp31.Enums;
using ConsoleApp31.Menu.BlogControllerSubMenus;

namespace ConsoleApp31.Menu
{
    public class BlogControllerMenu
    {
        private readonly int _id;
        private readonly BlogService _service;

        public BlogControllerMenu(int id, BlogService service)
        {
            _id = id;
            _service = service;
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
                                BlogCRUDMenu blogMenu = new BlogCRUDMenu(_id, _service);
                                blogMenu.BlogMenu();
                                break;
                            }
                        case BlogMenuControllerOptions.Commentary:
                            {
                                CommentaryCRUDMenu commentMenu = new CommentaryCRUDMenu(_id, _service);
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
