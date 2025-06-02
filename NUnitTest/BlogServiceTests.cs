using DataAccessLayer.Interfaces.UnitOfWorkInterface;
using DataAccessLayer.Interfaces.EntityRepositoryIntefaces;
using BusinessLogicLayer.Services;
using Moq;
using ConsoleApp31.Entity;
using BusinessLogicLayer.DataTransferObjects.BlogDto;

[TestFixture]
public class BlogServiceTests
{
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private Mock<IBlogRepository> _mockBlogRepository;
    private BlogService _blogService;

    [SetUp]
    public void Setup()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockBlogRepository = new Mock<IBlogRepository>();
        _mockUnitOfWork.Setup(u => u.Blogs).Returns(_mockBlogRepository.Object);

        _blogService = new BlogService(_mockUnitOfWork.Object);
    }

    [Test]
    public void AddBlog_Should_Add_And_Save()
    {
        var dto = new BlogCreateDto { Title = "Title", Content = "Content", AuthorId = 1 };
        _blogService.AddBlog(dto);
        _mockBlogRepository.Verify(r => r.Add(It.IsAny<BlogEntity>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
    }
    [Test]
    public void DeleteBlog_Should_Delete_And_Save_If_Blog_Exists()
    {
        var blog = new BlogEntity { Id = 1 };
        _mockBlogRepository.Setup(r => r.GetBlogWithComments(1)).Returns(blog);
        _blogService.DeleteBlog(1);
        _mockBlogRepository.Verify(r => r.Delete(blog), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Once);
    }

    [Test]
    public void DeleteBlog_Should_Not_Delete_If_Blog_Not_Found()
    {
        _mockBlogRepository.Setup(r => r.GetBlogWithComments(1)).Returns((BlogEntity)null);
        _blogService.DeleteBlog(1);
        _mockBlogRepository.Verify(r => r.Delete(It.IsAny<BlogEntity>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChanges(), Times.Never);
    }

    [Test]
    public void GetAllBlog_Should_Return_Mapped_DTOs()
    {
        var blogs = new List<BlogEntity>
        {
            new BlogEntity
            {
                Id = 1,
                Title = "Test Blog",
                Content = "Test Content",
                AuthorId = 1,
                Author = new UserEntity { Login = "testuser" },
                Comments = new List<CommentaryEntity>
                {
                    new CommentaryEntity { Content = "Nice!", User = new UserEntity { Login = "commenter" } }
                }
            }
        };

        _mockBlogRepository.Setup(r => r.GetBlogsWithAuthorsAndComments()).Returns(blogs);
        var result = _blogService.GetAllBlog().ToList();
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Title, Is.EqualTo("Test Blog"));
        Assert.That(result[0].Author, Is.EqualTo("testuser"));
        Assert.That(result[0].Comments.Count, Is.EqualTo(1));
        Assert.That(result[0].Comments[0].Content, Is.EqualTo("Nice!"));
    }
}
