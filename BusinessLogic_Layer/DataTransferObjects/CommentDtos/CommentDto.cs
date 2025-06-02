namespace BusinessLogicLayer.DataTransferObjects.CommentDtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string? User { get; set; }
    }
}
