using MediatR;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Application.Dtos.UsersManage;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Application.UsersManage.RegisterUser.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly ITaskManagerDbContext _taskManagerDbContext;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(ITaskManagerDbContext taskManagerDbContext, IPasswordHasher passwordHasher)
        {
            _taskManagerDbContext = taskManagerDbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.HashPassword(request.RegisterUserDto.Password);
            var user = RegisterUser(request.RegisterUserDto, hashedPassword);

            _taskManagerDbContext.Users.Add(user);
            await _taskManagerDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
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
}
