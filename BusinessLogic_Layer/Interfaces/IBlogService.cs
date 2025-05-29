using ConsoleApp31.Entity;
using DataAccessLayer.DataTransferObjects;

namespace BusinessLogic_Layer.Interfaces
{
    public interface IBlogService
    {
        public void AddBlog(BlogDto dto);
        public void DeleteBlog(int blogId);
        public void UpdateBlog(BlogDto dto);
        public IEnumerable<BlogDto> GetAllBlog();
        public void ShowAllBlogsWithDetails();
    }
}
