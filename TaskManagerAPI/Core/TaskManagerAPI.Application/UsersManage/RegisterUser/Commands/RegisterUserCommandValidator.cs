using FluentValidation;

namespace TaskManagerAPI.Application.UsersManage.RegisterUser.Commands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.RegisterUserDto.UserName)
            .NotNull().WithMessage("UserName cannot be null.")
            .NotEmpty().WithMessage("UserName cannot be empty.")
            .MinimumLength(3).WithMessage("UserName must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("UserName cannot be longer than 20 characters.");
        }
    }
}