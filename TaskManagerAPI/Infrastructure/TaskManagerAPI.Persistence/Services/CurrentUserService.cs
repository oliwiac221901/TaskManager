using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TaskManagerAPI.Application.Common.Interfaces;

namespace TaskManagerAPI.Persistence.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? userId =>
        _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? userName =>
        _httpContextAccessor.HttpContext?.User?.Identity?.Name;
}
