using Application.DTOs.Responses.User;
using MediatR;

namespace Application.User.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
