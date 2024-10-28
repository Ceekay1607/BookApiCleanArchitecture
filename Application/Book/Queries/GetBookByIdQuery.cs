using Application.DTOs.Responses.Book;
using MediatR;

namespace Application.Book.Queries;

public class GetBookByIdQuery : IRequest<BookResponse>
{
    public int Id { get; set; }

    public GetBookByIdQuery(int bookId)
    {
        Id = bookId;
    }
}
