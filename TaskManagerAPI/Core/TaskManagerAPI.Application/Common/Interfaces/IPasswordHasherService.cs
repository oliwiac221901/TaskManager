namespace TaskManagerAPI.Application.Common.Interfaces;

public interface IPasswordHasherService
{
    string HashPassword(string password);
    bool VerifyPassword(string hash, string password);
}
