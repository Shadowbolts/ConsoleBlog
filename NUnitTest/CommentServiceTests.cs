using Moq;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces.UnitOfWorkInterface;
using DataAccessLayer.Interfaces.EntityRepositoryIntefaces;
using BusinessLogicLayer.DataTransferObjects.CommentDtos;
using ConsoleApp31.Entity;
[TestFixture]
public class CommentServiceTests
{
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private Mock<ICommentRepository> _mockCommentRepository;
    private CommentService _commentService;

    [SetUp]
    public void Setup()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockCommentRepository = new Mock<ICommentRepository>();
        _mockUnitOfWork.Setup(u => u.Comments).Returns(_mockCommentRepository.Object);

        _commentService = new CommentService(_mockUnitOfWork.Object);
    }

    [Test]
    public void AddComment_Should_Add_And_Save()
    {
        var dto = new CommentCreateDto { Content = "Test comment", BlogId = 1, UserId = 2 };

        _commentService.AddComment(dto);

        _mockCommentRepository.Verify(r => r.Add(It.Is<CommentaryEntity>(c =>
            c.Content == dto.Content &&
            c.BlogId == dto.BlogId &&
            c.UserId == dto.UserId
        )), Times.Once);

        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
    }

    [Test]
    public void DeleteComment_Should_Delete_And_Save_If_Comment_Exists()
    {
        var comment = new CommentaryEntity { Id = 1 };
        _mockCommentRepository.Setup(r => r.GetById(1)).Returns(comment);

        _commentService.DeleteComment(1);

        _mockCommentRepository.Verify(r => r.Delete(comment), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
    }

    [Test]
    public void DeleteComment_Should_Not_Delete_If_Comment_Not_Found()
    {
        _mockCommentRepository.Setup(r => r.GetById(1)).Returns((CommentaryEntity)null);

        _commentService.DeleteComment(1);

        _mockCommentRepository.Verify(r => r.Delete(It.IsAny<CommentaryEntity>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Never);
    }

    [Test]
    public void UpdateComment_Should_Update_And_Save()
    {
        var dto = new CommentUpdateDto { CommentId = 1, Content = "Updated content" };
        var commentEntity = new CommentaryEntity { Id = 1, Content = "Old content" };

        _mockCommentRepository.Setup(r => r.GetById(dto.CommentId)).Returns(commentEntity);

        _commentService.UpdateComment(dto);

        Assert.That(commentEntity.Content, Is.EqualTo(dto.Content));
        _mockCommentRepository.Verify(r => r.Update(commentEntity), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
    }

    [Test]
    public void GetAllComments_Should_Return_Mapped_DTOs()
    {
        var comments = new List<CommentaryEntity>
        {
            new CommentaryEntity
            {
                Id = 1,
                Content = "Test comment",
                User = new UserEntity { Login = "testuser" }
            }
        };

        _mockCommentRepository.Setup(r => r.GetAllWithUsersAndBlogs()).Returns(comments);

        var result = _commentService.GetAllComments().ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].CommentId, Is.EqualTo(1));
        Assert.That(result[0].Content, Is.EqualTo("Test comment"));
        Assert.That(result[0].User, Is.EqualTo("testuser"));
    }

    [Test]
    public void GetCommentsByBlog_Should_Return_Mapped_DTOs()
    {
        var blogId = 1;
        var comments = new List<CommentaryEntity>
        {
            new CommentaryEntity
            {
                Id = 2,
                Content = "Comment for blog",
                User = new UserEntity { Login = "bloguser" }
            }
        };

        _mockCommentRepository.Setup(r => r.GetCommentsByBlog(blogId)).Returns(comments);

        var result = _commentService.GetCommentsByBlog(blogId).ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].CommentId, Is.EqualTo(2));
        Assert.That(result[0].Content, Is.EqualTo("Comment for blog"));
        Assert.That(result[0].User, Is.EqualTo("bloguser"));
    }
}
