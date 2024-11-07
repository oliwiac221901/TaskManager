using FluentValidation;

namespace TaskManagerAPI.Application.TasksManage.TaskLists.Commands;

public class TaskListCommandValidator : AbstractValidator<TaskListCommand>
{
    public TaskListCommandValidator()
    {
        RuleFor(tl => tl.TaskListDto.TaskListName)
            .NotEmpty().WithMessage("TaskListName cannot be empty!")
            .MinimumLength(3).WithMessage("TaskListName must have at least 3 characters!")
            .MaximumLength(30).WithMessage("TaskListName cannot be longer than 30 characters!");
    }
}
