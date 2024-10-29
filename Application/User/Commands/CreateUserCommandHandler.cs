using Application.DTOs.Requests.User;
using Application.Interfaces;
using MediatR;

namespace Application.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserService _userService;
    public CreateUserCommandHandler(IUserService userService) {
        _userService = userService;
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.Register(new RegisterRequest{Username = request.Username, Password = request.Password, Admin = request.Admin});
        return user.Id;
    }
}
