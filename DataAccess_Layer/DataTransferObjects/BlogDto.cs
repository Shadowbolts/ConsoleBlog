namespace DataAccessLayer.DataTransferObjects
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Author { get; set; }
        public int AuthorId { get; set; }
        public List<CommentDto> Comments { get; set; } = new();
    }
}
