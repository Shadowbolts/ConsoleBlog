namespace DataAccessLayer.DataTransferObjects
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string? User { get; set; }
    }
}
