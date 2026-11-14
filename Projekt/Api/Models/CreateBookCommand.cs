namespace Api.Models;

public class CreateBookCommand
{
    public string? Title { get; set; }
    public int ReleaaseYear { get; set; }
    public string? Author { get; set; }
}
