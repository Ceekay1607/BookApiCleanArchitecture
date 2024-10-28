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
        var book = new CreateBookRequest { Title = request.Title, Author = request.Author, Price = request.Price };
        var bookId = await _bookRepository.CreateBookAsync(book);

        return bookId;
    }   
}
