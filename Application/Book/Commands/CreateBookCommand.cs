using MediatR;

namespace Application.Book.Commands;

public record class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }
}
