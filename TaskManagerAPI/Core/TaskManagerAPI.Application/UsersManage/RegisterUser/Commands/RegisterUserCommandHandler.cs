using MediatR;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Application.Dtos.UsersManage;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Application.UsersManage.RegisterUser.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly ITaskManagerDbContext _taskManagerDbContext;

        public RegisterUserCommandHandler(ITaskManagerDbContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = RegisterUser(request.RegisterUserDto);

            _taskManagerDbContext.Users.Add(user);
            await _taskManagerDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        private static User RegisterUser(RegisterUserDto registerUserDto)
        {
            return new User
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                Password = registerUserDto.Password
            };
        }
    }
}
