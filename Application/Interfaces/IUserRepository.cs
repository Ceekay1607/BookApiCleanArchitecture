using Application.DTOs.Requests.User;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<Domain.Entities.User> GetUserAsync(LoginRequest loginRequest);
    Task<Domain.Entities.User> AddAsync(RegisterRequest registerRequest);
}
