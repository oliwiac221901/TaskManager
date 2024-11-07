using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TaskManagerAPI.Application.Common.ExceptionsError;
using TaskManagerAPI.Application.Common.Interfaces;

namespace TaskManagerAPI.Persistence.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UserId
    {
        get
        {
            var userIdValue = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdValue) || !int.TryParse(userIdValue, out var id))
            {
                throw new UnauthorizedAccessException("User is not authorized!");
            }

            return id;
        }
    }

    public string UserName =>
        _httpContextAccessor.HttpContext.User.Identity.Name;


}
