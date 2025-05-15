using ConsoleApp31.DataBase;
using ConsoleApp31.Enums;

namespace ConsoleApp31.Menu.BlogControllerSubMenus
{
    public class BlogCRUDMenu
    {
        private readonly int _id;
        private readonly BlogService _service;
        public BlogCRUDMenu(int id, BlogService service)
        {
            _id = id;
            _service = service;
        }
        public void BlogMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Додати блог\n2. Видалити блог\n3. Оновити блог\n9. Вихід");
                if (Enum.TryParse(Console.ReadLine(), out CRUDMenuOptions choice))
                {
                    switch (choice)
                    {
                        case CRUDMenuOptions.Remove:
                            {
                                var blogs = _service.GetAllBlogs();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                _service.DeleteBlogWithComments(blogId);
                                break;
                            }
                        case CRUDMenuOptions.Update:
                            {
                                var blogs = _service.GetAllBlogs();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                Console.Write("Введіть нову назву блога: ");
                                string newTitle = Console.ReadLine()!;
                                Console.Write("Введіть новий вміст блога: ");
                                string newContent = Console.ReadLine()!;
                                _service.UpdateBlog(blogId, newTitle, newContent);
                                break;
                            }
                        case CRUDMenuOptions.Add:
                            {
                                Console.Write("Введіть назву блога: ");
                                string title = Console.ReadLine()!;
                                Console.Write("Введіть вміст блога: ");
                                string content = Console.ReadLine()!;
                                _service.AddBlogByCurrentAuthor(title, content, _id);
                                break;
                            }
                        case CRUDMenuOptions.Exit:
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
