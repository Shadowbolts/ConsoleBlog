using ConsoleApp31.DataBase;
using ConsoleApp31.Enums;

namespace ConsoleApp31.Menu.BlogControllerSubMenus
{
    public class CommentaryCRUDMenu
    {
        private readonly int _id;
        private readonly BlogService _service;
        public CommentaryCRUDMenu(int id, BlogService service)
        {
            _id = id;
            _service = service;
        }
        public void CommentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Додати коментарій\n2. Видалити коментарій\n3. Оновити коментарій\n9. Вихід");
                if (Enum.TryParse(Console.ReadLine(), out CRUDMenuOptions choice))
                {
                    switch (choice)
                    {
                        case CRUDMenuOptions.Remove:
                            {
                                var blogs = _service.GetAllBlogs();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                var comments = _service.GetCommentsByBlog(blogId);
                                int commentId = MenuHelper.CommentPrint(comments);
                                _service.DeleteComment(commentId);
                                break;
                            }
                        case CRUDMenuOptions.Update:
                            {
                                var blogs = _service.GetAllBlogs();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                var comments = _service.GetCommentsByBlog(blogId);
                                int commentId = MenuHelper.CommentPrint(comments);
                                Console.Write("Введіть новий текст: ");
                                string newContent = Console.ReadLine()!;
                                _service.UpdateCommentary(commentId, newContent);
                                break;
                            }
                        case CRUDMenuOptions.Add:
                            {
                                var blogs = _service.GetAllBlogs();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                Console.Write("Введіть текст: ");
                                string content = Console.ReadLine()!;
                                _service.AddCommentToBlog(content, blogId, _id);
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
