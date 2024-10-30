namespace TaskManagerAPI.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string hashPassword, string inputPassword);
    }
}