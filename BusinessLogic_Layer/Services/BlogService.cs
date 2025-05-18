using BusinessLogic_Layer.Interfaces;
using DataAccess_Layer.Repos.EntityRepositoryIntefaces;
using ConsoleApp31.Entity;
using ConsoleApp31.Repos;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic_Layer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public void AddBlog(string title, string content, int authorId)
        {
            var blog = new BlogEntity
            {
                Title = title,
                Content = content,
                AuthorId = authorId
            };
            _blogRepository.Add(blog);
        }

        public void DeleteBlog(int blogId)
        {
            var blog = _blogRepository.GetBlogWithComments(blogId);
            if (blog != null)
            {
                _blogRepository.Delete(blog);
            }
        }
        public void UpdateBlog(int blogId, string newTitle, string newContent)
        {
            var blog = _blogRepository.GetById(blogId);
            blog.Title = newTitle;
            blog.Content = newContent;
            _blogRepository.Update(blog);
        }
        public IEnumerable<BlogEntity> GetAllBlog()
        {
            return _blogRepository.GetAll();
        }
        public void ShowAllBlogsWithDetails()
        {
            var blogs = _blogRepository.GetBlogsWithAuthorsAndComments();
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
