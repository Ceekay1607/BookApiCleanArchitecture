using MediatR;

namespace Application.Book.Commands;

public class DeleteBookCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteBookCommand(int id) {
        Id = id;
    }
}
