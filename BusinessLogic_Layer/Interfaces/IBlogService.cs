using BusinessLogicLayer.DataTransferObjects.BlogDto;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBlogService
    {
        public void AddBlog(BlogCreateDto dto);
        public void DeleteBlog(int blogId);
        public void UpdateBlog(BlogUpdateDto dto);
        public IEnumerable<BlogDto> GetAllBlog();
        public void ShowAllBlogsWithDetails();
    }
}
