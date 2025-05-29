using DataAccessLayer.DataTransferObjects;

namespace ConsoleApp31.Menu
{
    public static class MenuHelper
    {
        public static int BlogPrint(IEnumerable<BlogDto> blogs)
        {
            Console.WriteLine("Оберіть айді блогу:");
            foreach (var blog in blogs)
            {
                Console.WriteLine($"{blog.Id}: {blog.Title}");
            }

            int blogId = int.Parse(Console.ReadLine()!);
            return blogId;
        }
        public static int CommentPrint(IEnumerable<CommentDto> comments)
        {
            Console.WriteLine("Оберіть коментарій:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"{comment.Id}: {comment.Content}");
            }
            int commentId = int.Parse(Console.ReadLine()!);
            return commentId;
        }
    }
}
