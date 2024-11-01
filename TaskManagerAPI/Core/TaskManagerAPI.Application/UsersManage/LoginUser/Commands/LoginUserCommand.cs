using MediatR;
using TaskManagerAPI.Application.Dtos.UsersManage;

namespace TaskManagerAPI.Application.UsersManage.LoginUser.Commands;

public class LoginUserCommand : IRequest<string>
{
    public LoginUserDto LoginUserDto { get; set; }
}
