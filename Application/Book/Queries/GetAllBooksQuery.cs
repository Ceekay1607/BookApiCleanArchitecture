using Application.DTOs.Responses.Book;
using MediatR;

namespace Application.Book.Queries;

public class GetAllBooksQuery : IRequest<List<BookResponse>>
{
}
