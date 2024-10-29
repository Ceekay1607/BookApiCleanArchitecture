namespace Application.DTOs.Responses.Book;

public class BookResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public string? Author { get; set; }

    public double Price { get; set; }
}
