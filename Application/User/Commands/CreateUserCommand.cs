using System.Net;
using MediatR;

namespace Application.User.Commands;

public record class CreateUserCommand : IRequest<int>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Admin { get; set; }
}
