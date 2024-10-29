using Application.DTOs.Requests.User;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher;


    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();

    }

    public async Task<User> AddAsync(RegisterRequest registerRequest)
    {
        var user = new User { Username = registerRequest.Username, Admin = registerRequest.Admin };
        user.Password = _passwordHasher.HashPassword(user, registerRequest.Password);

        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetUserAsync(LoginRequest loginRequest)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password) == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        return user;
    }
}
