using Application.Interfaces;
using MediatR;

namespace Application.Book.Commands;

public class UpdateBookPriceCommandHandler : IRequestHandler<UpdateBookPriceCommand, bool>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookPriceCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<bool> Handle(UpdateBookPriceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _bookRepository.UpdateBookPriceAsync(request.Id, request.NewPrice);
            return true; 
        }
        catch
        {
            throw; 
        }
    }
}
