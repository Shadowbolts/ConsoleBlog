namespace ConsoleApp31.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<CommentaryEntity> Comments { get; set; } = [];
        public List<BlogEntity> Blogs { get; set; } = [];
    }
}
