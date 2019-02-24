namespace PaintStore.Domain.Entities
{
    public partial class CommentLikes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
