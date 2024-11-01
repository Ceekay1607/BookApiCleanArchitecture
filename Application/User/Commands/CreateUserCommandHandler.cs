using Application.DTOs.Requests.User;
using Application.Interfaces;
using MediatR;

namespace Application.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.AddAsync(new RegisterRequest{Username = request.Username, Password = request.Password, Admin = request.Admin});
        return user.Id;
    }
}
