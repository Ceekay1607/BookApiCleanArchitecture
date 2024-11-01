using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);

}
