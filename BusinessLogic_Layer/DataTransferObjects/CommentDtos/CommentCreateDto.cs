namespace BusinessLogicLayer.DataTransferObjects.CommentDtos
{
    public class CommentCreateDto
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
