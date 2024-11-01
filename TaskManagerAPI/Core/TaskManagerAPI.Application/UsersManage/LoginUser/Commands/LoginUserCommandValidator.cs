using FluentValidation;

namespace TaskManagerAPI.Application.UsersManage.LoginUser.Commands;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(r => r.LoginUserDto.UserName)
            .NotEmpty().WithMessage("UserName cannot be empty!");

        RuleFor(r => r.LoginUserDto.Password)
            .NotEmpty().WithMessage("Password cannot be empty!");
    }
}
