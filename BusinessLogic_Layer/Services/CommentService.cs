using BusinessLogicLayer.Interfaces;
using ConsoleApp31.Entity;
using DataAccessLayer.Interfaces.UnitOfWorkInterface;
using BusinessLogicLayer.DataTransferObjects.CommentDtos;

namespace BusinessLogicLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public void AddComment(CommentCreateDto dto)
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
        public void UpdateComment(CommentUpdateDto dto)
        {
            var comments = _unitOfWork.Comments.GetById(dto.CommentId);
            comments.Content = dto.Content;
            _unitOfWork.Comments.Update(comments);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<CommentDto> GetAllComments()
        {
            var comments = _unitOfWork.Comments.GetAllWithUsersAndBlogs();

            return comments.Select(c => new CommentDto
            {
                CommentId = c.Id,
                UserId = c.UserId,
                BlogId = c.BlogId,
                Content = c.Content,
                User = c.User?.Login
            });
        }

        public IEnumerable<CommentDto> GetCommentsByBlog(int blogId)
        {
            var comments = _unitOfWork.Comments.GetCommentsByBlog(blogId);

            return comments.Select(c => new CommentDto
            {
                Content = c.Content,
                User = c.User?.Login,
                CommentId = c.Id
            });
        }
    }
}
