using Application.DTOs.Responses.Book;
using Application.Interfaces;
using MediatR;

namespace Application.Book.Queries;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
{
   private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);
            if (book == null)
            {
                return null; 
            }

            return new BookResponse
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }
}
