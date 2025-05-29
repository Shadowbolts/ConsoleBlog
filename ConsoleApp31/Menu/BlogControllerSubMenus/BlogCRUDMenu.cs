using BusinessLogic_Layer.Interfaces;
using BusinessLogic_Layer.Services;
using ConsoleApp31.Enums;
using DataAccessLayer.DataTransferObjects;

namespace ConsoleApp31.Menu.BlogControllerSubMenus
{
    public class BlogCRUDMenu
    {
        private readonly int _id;
        private readonly IBlogService _blogService;
        public BlogCRUDMenu(int id, IBlogService blogService)
        {
            _id = id;
            _blogService = blogService;
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
                                var blogs = _blogService.GetAllBlog();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                _blogService.DeleteBlog(blogId);
                                break;
                            }
                        case CRUDMenuOptions.Update:
                            {
                                var blogs = _blogService.GetAllBlog();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                Console.Write("Введіть нову назву блога: ");
                                string newTitle = Console.ReadLine()!;
                                Console.Write("Введіть новий вміст блога: ");
                                string newContent = Console.ReadLine()!;
                                var blogDto = new BlogDto
                                {
                                    Id = blogId,
                                    Title = newTitle,
                                    Content = newContent
                                };
                                _blogService.UpdateBlog(blogDto);
                                break;
                            }
                        case CRUDMenuOptions.Add:
                            {
                                Console.Write("Введіть назву блога: ");
                                string title = Console.ReadLine()!;
                                Console.Write("Введіть вміст блога: ");
                                string content = Console.ReadLine()!;
                                var blogDto = new BlogDto
                                {
                                    Title = title,
                                    Content = content,
                                    AuthorId = _id
                                };
                                _blogService.AddBlog(blogDto);
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
