namespace TaskManagerAPI.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? userId { get; }
    string? userName { get; }
}
