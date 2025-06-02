using BusinessLogicLayer.DataTransferObjects.CommentDtos;

namespace BusinessLogicLayer.DataTransferObjects.BlogDto
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Author { get; set; }
        public int AuthorId { get; set; }
        public List<CommentDto> Comments { get; set; } = new();
    }
}
