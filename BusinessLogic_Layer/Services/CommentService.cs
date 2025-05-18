using BusinessLogic_Layer.Interfaces;
using ConsoleApp31.Entity;
using DataAccess_Layer.Repos.EntityRepositoryIntefaces;

namespace BusinessLogic_Layer.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository) 
        {
            _commentRepository = commentRepository;
        }
        public void AddComment(string content, int blogId, int userId)
        {
            var comment = new CommentaryEntity
            {
                Content = content,
                BlogId = blogId,
                UserId = userId,
            };
            _commentRepository.Add(comment);
        }
        public void DeleteComment(int commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            if (comment != null)
            {
                _commentRepository.Delete(comment);
            }
        }
        public void UpdateComment(int commentId, string newContent)
        {
            var comments = _commentRepository.GetById(commentId);
            comments.Content = newContent;
            _commentRepository.Update(comments);
        }
        public IEnumerable<CommentaryEntity> GetAllComments()
        {
            return _commentRepository.GetAll();
        }
        public IEnumerable<CommentaryEntity> GetCommentsByBlog(int blogId)
        {
            return _commentRepository.GetCommentsByBlog(blogId);
        }
    }
}
