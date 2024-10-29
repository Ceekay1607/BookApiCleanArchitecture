using Application.DTOs.Requests.User;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Domain.Entities.User> Register(RegisterRequest registerRequest);
}
