using ConsoleApp31.Entity;
using DataAccessLayer.DataTransferObjects;

namespace BusinessLogic_Layer.Interfaces
{
    public interface ICommentService
    {
        public void AddComment(CommentDto dto);
        public void DeleteComment(int commentId);
        public void UpdateComment(CommentDto dto);
        public IEnumerable<CommentDto> GetAllComments();
        public IEnumerable<CommentDto> GetCommentsByBlog(int BlogId);
    }
}
