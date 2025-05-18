using BusinessLogic_Layer.Interfaces;
using BusinessLogic_Layer.Services;
using ConsoleApp31.Enums;

namespace ConsoleApp31.Menu.BlogControllerSubMenus
{
    public class CommentaryCRUDMenu
    {
        private readonly int _id;
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        public CommentaryCRUDMenu(int id, IBlogService blogService, ICommentService commentService)
        {
            _id = id;
            _blogService = blogService;
            _commentService = commentService;
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
                                var blogs = _blogService.GetAllBlog();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                var comments = _commentService.GetCommentsByBlog(blogId);
                                int commentId = MenuHelper.CommentPrint(comments);
                                _commentService.DeleteComment(commentId);
                                break;
                            }
                        case CRUDMenuOptions.Update:
                            {
                                var blogs = _blogService.GetAllBlog();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                var comments = _commentService.GetCommentsByBlog(blogId);
                                int commentId = MenuHelper.CommentPrint(comments);
                                Console.Write("Введіть новий текст: ");
                                string newContent = Console.ReadLine()!;
                                _commentService.UpdateComment(commentId, newContent);
                                break;
                            }
                        case CRUDMenuOptions.Add:
                            {
                                var blogs = _blogService.GetAllBlog();
                                int blogId = MenuHelper.BlogPrint(blogs);
                                Console.Write("Введіть текст: ");
                                string content = Console.ReadLine()!;
                                _commentService.AddComment(content, blogId, _id);
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
