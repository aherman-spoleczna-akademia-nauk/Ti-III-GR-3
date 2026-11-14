using Api.Models;

namespace Api;

public class BookService
{
    private List<Book> _books;

    public BookService()
    {
        _books = new List<Book>();
        _books.Add(new Book
        {
            Title = "Władca Pierścieni",
            ReleaaseYear = 1954,
            Author = "J.R.R. Tolkien"
        });

        _books.Add(new Book
        {
            Title = "Potop",
            ReleaaseYear = 1900,
            Author = "Henryk Sienkiewicz"
        });
    }

    public List<Book> GetBooks(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return _books;

        return _books.Where(b => b.Title.StartsWith(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public ApiResult AddNewBook(CreateBookCommand command)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(command.Title))
            errors.Add("Brak tytułu");

        if (string.IsNullOrWhiteSpace(command.Author))
            errors.Add("Brak autora");


        if (command.ReleaaseYear <= 0)
            errors.Add("Nieprawidłowa data wydania");

        if (errors.Count > 0)
            return new ApiResult { Success = false, Error = string.Join(", ", errors) };

        var book = new Book
        {
            Title = command.Title,
            ReleaaseYear = command.ReleaaseYear,
            Author = command.Author
        };

        _books.Add(book);
        return new ApiResult { Success = true };
    }
}
