using MediatR;

namespace Application.Book.Commands;

public class UpdateBookPriceCommand : IRequest<bool>
{
    public int Id {get; set;}
    public double NewPrice{get; set;}

    public UpdateBookPriceCommand(int id, double newPrice) {
        Id = id;
        NewPrice = newPrice;
    }
}
