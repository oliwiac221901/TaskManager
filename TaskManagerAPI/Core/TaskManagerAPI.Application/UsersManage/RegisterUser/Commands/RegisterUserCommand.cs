using MediatR;
using TaskManagerAPI.Application.Dtos.UsersManage;

namespace TaskManagerAPI.Application.UsersManage.RegisterUser.Commands
{
    public class RegisterUserCommand : IRequest<int>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}
