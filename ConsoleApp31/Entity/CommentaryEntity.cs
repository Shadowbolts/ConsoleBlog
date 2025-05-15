namespace ConsoleApp31.Entity
{
    public class CommentaryEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public UserEntity? User { get; set; }
        public int UserId { get;set; }
        public BlogEntity? Blog { get; set; }
        public int BlogId { get; set; }
    }
}
