using FluentValidation;

namespace TaskManagerAPI.Application.UsersManage.RegisterUser.Commands;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.RegisterUserDto.UserName)
            .NotEmpty().WithMessage("UserName cannot be empty!")
            .MinimumLength(3).WithMessage("UserName must have at least 3 characters!")
            .MaximumLength(15).WithMessage("UserName cannot be longer than 20 characters!");

        RuleFor(r => r.RegisterUserDto.Email)
            .NotEmpty().WithMessage("Email cannot be empty!")
            .EmailAddress().WithMessage("Invalid email format!")
            .MaximumLength(30).WithMessage("Email cannot be longer than 50 characters!");

        RuleFor(r => r.RegisterUserDto.Password)
            .NotEmpty().WithMessage("Password cannot be empty!")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters!")
            .MaximumLength(20).WithMessage("Password cannot be longer than 20 characters!");
    }
}
