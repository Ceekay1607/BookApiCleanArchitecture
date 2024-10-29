using Application.DTOs.Requests.User;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }
    public async Task<User> Register(RegisterRequest registerRequest)
    {
        return await _userRepository.AddAsync(registerRequest);
    }
}
