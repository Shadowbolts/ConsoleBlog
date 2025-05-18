using ConsoleApp31.Entity;

namespace BusinessLogic_Layer.Interfaces
{
    public interface IBlogService
    {
        public void AddBlog(string title, string content, int authorId);
        public void DeleteBlog(int blogId);
        public void UpdateBlog(int blogId, string newTitle, string newContent);
        public IEnumerable<BlogEntity> GetAllBlog();
        public void ShowAllBlogsWithDetails();
    }
}
