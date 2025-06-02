using BusinessLogicLayer.DataTransferObjects.CommentDtos;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICommentService
    {
        public void AddComment(CommentCreateDto dto);
        public void DeleteComment(int commentId);
        public void UpdateComment(CommentUpdateDto dto);
        public IEnumerable<CommentDto> GetAllComments();
        public IEnumerable<CommentDto> GetCommentsByBlog(int BlogId);
    }
}
