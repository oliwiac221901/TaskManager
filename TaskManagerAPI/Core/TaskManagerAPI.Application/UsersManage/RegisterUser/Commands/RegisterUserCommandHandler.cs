using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application.Common.ExceptionsError;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Application.Dtos.UsersManage;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Application.UsersManage.RegisterUser.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private readonly ITaskManagerDbContext _taskManagerDbContext;
    private readonly IPasswordHasherService _passwordHasherService;

    public RegisterUserCommandHandler(ITaskManagerDbContext taskManagerDbContext, IPasswordHasherService passwordHasherService)
    {
        _taskManagerDbContext = taskManagerDbContext;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await EnsureUserNotExists(request.RegisterUserDto.UserName, cancellationToken);
        var hashedPassword = _passwordHasherService.HashPassword(request.RegisterUserDto.Password);
        var user = RegisterUser(request.RegisterUserDto, hashedPassword);

        _taskManagerDbContext.Users.Add(user);
        await _taskManagerDbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    private async Task EnsureUserNotExists(string userName, CancellationToken cancellationToken)
    {
        var userStatus = await _taskManagerDbContext.Users
            .AnyAsync(u => u.UserName == userName, cancellationToken);

        if (userStatus)
            throw new ConflictException("User already exists!");
    }

    private static User RegisterUser(RegisterUserDto registerUserDto, string hashedPassword)
    {
        return new User
        {
            UserName = registerUserDto.UserName,
            Email = registerUserDto.Email,
            Password = hashedPassword
        };
    }
}
