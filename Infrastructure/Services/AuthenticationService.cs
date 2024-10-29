using Application.DTOs.Requests.User;
using Application.DTOs.Responses.User;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async Task<string> Login(LoginRequest loginRequest)
    {
        User user = await _userRepository.GetUserAsync(loginRequest);

        return _tokenService.GenerateToken(user);
    }
}
