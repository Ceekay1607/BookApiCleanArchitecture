using Application.DTOs.Requests.User;
using Application.DTOs.Responses.User;
using Application.Interfaces;
using MediatR;

namespace Application.User.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthenticationService _authenticationService;
    public LoginCommandHandler(IAuthenticationService authenticationService) {
        _authenticationService = authenticationService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _authenticationService.Login(new LoginRequest
            {
                Username = request.Username,
                Password = request.Password
            });

            return new LoginResponse { Username = request.Username, Token = token };;
        }
        catch 
        {
            throw;
        }
    }
}
