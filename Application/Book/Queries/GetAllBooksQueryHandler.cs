using Application.DTOs.Responses.Book;
using Application.Interfaces;
using MediatR;

namespace Application.Book.Queries;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookResponse>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllBooksAsync();

        var bookResponses = new List<BookResponse>();
        foreach (var book in books)
        {
            bookResponses.Add(new BookResponse
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            });
        }

        return bookResponses;
    }
}
