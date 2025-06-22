namespace Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
}
