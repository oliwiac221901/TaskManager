namespace TaskManagerAPI.Application.Common.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(int userId, string userName);
}
