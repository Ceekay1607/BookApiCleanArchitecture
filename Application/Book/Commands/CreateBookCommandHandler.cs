using Application.DTOs.Requests.Book;
using Application.Interfaces;
using MediatR;

namespace Application.Book.Commands;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        if (request.Price <= 0)
        {
            throw new ArgumentException("Price must be a positive number.");
        }

        if (String.IsNullOrEmpty(request.Author) || String.IsNullOrEmpty(request.Title))
        {
            throw new ArgumentException("Attribute cannot be null");
        }

        var book = new CreateBookRequest { Title = request.Title, Author = request.Author, Price = request.Price };
        var bookId = await _bookRepository.CreateBookAsync(book);

        return bookId;
    }
}
