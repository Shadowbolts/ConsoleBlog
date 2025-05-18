namespace ConsoleApp31.Entity
{
    public class BlogEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<CommentaryEntity> Comments { get; set; } = [];
        public UserEntity? Author { get; set; }
        public int AuthorId { get; set; }
    }
}
