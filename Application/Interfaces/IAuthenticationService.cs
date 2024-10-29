using Application.DTOs.Requests.User;
using Application.DTOs.Responses.User;

namespace Application.Interfaces;

public interface IAuthenticationService
{
    Task<string> Login (LoginRequest loginRequest);
}
