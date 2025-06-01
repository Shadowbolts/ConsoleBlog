using BusinessLogic_Layer.Interfaces;
using ConsoleApp31.Entity;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces.UnitOfWorkInterface;

namespace BusinessLogic_Layer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void AddComment(CommentDto dto)
        {
            var comment = new CommentaryEntity
            {
                Content = dto.Content,
                BlogId = dto.BlogId,
                UserId = dto.UserId,
            };
            _unitOfWork.Comments.Add(comment);
            _unitOfWork.SaveChanges();
        }
        public void DeleteComment(int commentId)
        {
            var comment = _unitOfWork.Comments.GetById(commentId);
            if (comment != null)
            {
                _unitOfWork.Comments.Delete(comment);
                _unitOfWork.SaveChanges();
            }
        }
        public void UpdateComment(CommentDto dto)
        {
            var comments = _unitOfWork.Comments.GetById(dto.Id);
            comments.Content = dto.Content;
            _unitOfWork.Comments.Update(comments);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<CommentDto> GetAllComments()
        {
            var comments = _unitOfWork.Comments.GetAll();

            return comments.Select(c => new CommentDto
            {
                Content = c.Content,
                User = c.User?.Login,
                Id = c.Id
            });
        }

        public IEnumerable<CommentDto> GetCommentsByBlog(int blogId)
        {
            var comments = _unitOfWork.Comments.GetCommentsByBlog(blogId);

            return comments.Select(c => new CommentDto
            {
                Content = c.Content,
                User = c.User?.Login,
                Id = c.Id
            });
        }
    }
}
