namespace MyWebApplication.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
