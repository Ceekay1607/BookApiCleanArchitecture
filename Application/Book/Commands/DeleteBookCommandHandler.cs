using Application.Interfaces;
using MediatR;

namespace Application.Book.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _bookRepository.DeleteBookAsync(request.Id);
            return true;
        }
        catch
        {
            throw;
        }
    }
}
