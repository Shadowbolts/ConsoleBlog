using BusinessLogic_Layer.Interfaces;
using ConsoleApp31.Entity;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces.UnitOfWorkInterface;
namespace BusinessLogic_Layer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddBlog(BlogDto dto)
        {
            var blog = new BlogEntity
            {
                Title = dto.Title,
                Content = dto.Content,
                AuthorId = dto.AuthorId
            };
            _unitOfWork.Blogs.Add(blog);
            _unitOfWork.SaveChanges();
        }

        public void DeleteBlog(int blogId)
        {
            var blog = _unitOfWork.Blogs.GetBlogWithComments(blogId);
            if (blog != null)
            {
                _unitOfWork.Blogs.Delete(blog);
                _unitOfWork.SaveChanges();
            }
        }
        public void UpdateBlog(BlogDto dto)
        {
            var blog = _unitOfWork.Blogs.GetById(dto.Id);
            blog.Title = dto.Title;
            blog.Content = dto.Content;
            _unitOfWork.Blogs.Update(blog);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<BlogDto> GetAllBlog()
        {
            var blogs = _unitOfWork.Blogs.GetBlogsWithAuthorsAndComments();

            return blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                Author = b.Author?.Login,
                AuthorId = b.AuthorId,
                Comments = b.Comments.Select(c => new CommentDto
                {
                    Content = c.Content,
                    User = c.User?.Login
                }).ToList()
            });
        }
        public void ShowAllBlogsWithDetails()
        {
            var blogs = GetAllBlog();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"\nБлог: {blog.Title}");
                Console.WriteLine($"Автор: {blog.Author}");
                Console.WriteLine($"Вміст: {blog.Content}");
                Console.WriteLine("Коментарі:");

                foreach (var comment in blog.Comments)
                {
                    Console.WriteLine($"- {comment.Content} (автор: {comment.User})");
                }
            }
        }
    }
}
