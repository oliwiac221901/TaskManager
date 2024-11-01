using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application.Common.ExceptionsError;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Application.UsersManage.LoginUser.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly ITaskManagerDbContext _taskManagerDbContext;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginUserCommandHandler(ITaskManagerDbContext taskManagerDbContext, IPasswordHasherService passwordHasherService, IJwtTokenService jwtTokenService)
    {
        _taskManagerDbContext = taskManagerDbContext;
        _passwordHasherService = passwordHasherService;
        _jwtTokenService = jwtTokenService;
    }
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await EnsureUserExists(request.LoginUserDto.UserName, cancellationToken);
        var verifyPasswords = _passwordHasherService.VerifyPassword(user.Password, request.LoginUserDto.Password);

        if (!verifyPasswords)
            throw new BadRequestException("Invalid username or password!");

        return _jwtTokenService.GenerateToken(user.Id, user.UserName);
    }

    public async Task<User> EnsureUserExists(string userName, CancellationToken cancellationToken)
    {
        return await _taskManagerDbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken)
            ?? throw new NotFoundException("User does not exist!");
    }
}
