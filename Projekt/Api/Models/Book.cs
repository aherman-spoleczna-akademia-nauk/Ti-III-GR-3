namespace Api.Models;

public class Book
{
    public Guid BookId { get; set; } = Guid.CreateVersion7();
    public string Title { get; set; } = string.Empty;
    public int ReleaaseYear { get; set; }
    public string Author { get; set; } = string.Empty;
}
