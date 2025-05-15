using ConsoleApp31.Entity;
using ConsoleApp31.Repos;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp31.DataBase
{
    public class BlogService
    {
        private readonly BloggingDbContext _context;
        private readonly UserRepository userRepo;
        private readonly BlogRepository blogRepo;
        private readonly CommentaryRepository commentRepo;

        public BlogService(BloggingDbContext context)
        {
            _context = context;
            userRepo = new UserRepository(context);
            blogRepo = new BlogRepository(context);
            commentRepo = new CommentaryRepository(context);
        }

        public void AddBlogByCurrentAuthor(string title, string content, int id)
        {
            var blog = new BlogEntity
            {
                Title = title,
                Content = content,
                AuthorId = id
            };
            blogRepo.Add(blog);
        }
        public void AddCommentToBlog(string content, int blogId, int userId)
        {
            var blog = blogRepo.GetById(blogId);

            var comment = new CommentaryEntity
            {
                Content = content,
                BlogId = blogId,
                UserId = userId
            };

            commentRepo.Add(comment);
        }
        public void DeleteBlogWithComments(int blogId)
        {
            var blog = blogRepo.GetBlogWithComments(blogId);
            if (blog != null)
            {
                foreach (var comment in blog.Comments.ToList())
                {
                    commentRepo.Delete(comment);
                }

                blogRepo.Delete(blog);
            }
        }
        public void DeleteComment(int commentId)
        {
            var comment = commentRepo.GetById(commentId);
            if (comment != null)
            {
                commentRepo.Delete(comment);
            }
        }
        public void UpdateBlog(int blogId, string newTitle, string newContent)
        {
            var blog = blogRepo.GetById(blogId);
            blog.Title = newTitle;
            blog.Content = newContent;
            blogRepo.Update(blog);
        }
        public void UpdateCommentary(int commentaryId, string newContent)
        {
            var comments = commentRepo.GetById(commentaryId);
            comments.Content = newContent;
            commentRepo.Update(comments);
        }
        public IEnumerable<BlogEntity> GetAllBlogs()
        {
            return blogRepo.GetAll();
        }
        public IEnumerable<CommentaryEntity> GetCommentsByBlog(int blogId)
        {
            return commentRepo.GetCommentsByBlog(blogId);
        }
        public void ShowAllBlogsWithDetails()
        {
            var blogs = blogRepo.GetBlogsWithAuthorsAndComments();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"\nБлог: {blog.Title}");
                Console.WriteLine($"Автор: {blog.Author?.Login}");
                Console.WriteLine($"Вміст: {blog.Content}");
                Console.WriteLine("Коментарі:");

                foreach (var comment in blog.Comments)
                {
                    Console.WriteLine($"- {comment.Content} (автор: {comment.User?.Login})");
                }
            }
        }
    }
}
