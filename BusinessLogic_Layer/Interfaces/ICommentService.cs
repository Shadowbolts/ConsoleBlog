using ConsoleApp31.Entity;

namespace BusinessLogic_Layer.Interfaces
{
    public interface ICommentService
    {
        public void AddComment(string content, int blogId, int userId);
        public void DeleteComment(int commentId);
        public void UpdateComment(int commentId, string newContent);
        public IEnumerable<CommentaryEntity> GetAllComments();
        public IEnumerable<CommentaryEntity> GetCommentsByBlog(int BlogId);
    }
}
