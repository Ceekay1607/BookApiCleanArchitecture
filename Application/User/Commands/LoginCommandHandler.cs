using Application.DTOs.Requests.User;
using Application.DTOs.Responses.User;
using Application.Interfaces;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.User.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService) {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Entities.User user = await _userRepository.GetUserAsync(new LoginRequest
            {
                Username = request.Username,
                Password = request.Password
            });


            var token = _tokenService.GenerateToken(user);

            return new LoginResponse { Username = request.Username, Token = token };;
        }
        catch 
        {
            throw;
        }
    }
}
