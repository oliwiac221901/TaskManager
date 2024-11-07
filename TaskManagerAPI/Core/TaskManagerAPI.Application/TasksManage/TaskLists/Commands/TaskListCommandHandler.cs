using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application.Common.ExceptionsError;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Domain.Entities.TasksManage;

namespace TaskManagerAPI.Application.TasksManage.TaskLists.Commands;

public class TaskListCommandHandler : IRequestHandler<TaskListCommand, int>
{
    private readonly ITaskManagerDbContext _taskManagerDbContext;
    private readonly ICurrentUserService _currentUserService;

    public TaskListCommandHandler(ITaskManagerDbContext taskManagerDbContext, ICurrentUserService currentUserService)
    {
        _taskManagerDbContext = taskManagerDbContext;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(TaskListCommand request, CancellationToken cancellationToken)
    {
        await EnsureTaskListNotExists(request.TaskListDto.TaskListName, cancellationToken);
        var currentUser = _currentUserService.UserId;
        var taskList = CreateTaskList(request.TaskListDto.TaskListName, currentUser);

        _taskManagerDbContext.TaskLists.Add(taskList);
        await _taskManagerDbContext.SaveChangesAsync(cancellationToken);

        return taskList.TaskListId;
    }

    private async Task EnsureTaskListNotExists(string taskListName, CancellationToken cancellationToken)
    {
        var taskListStatus = await _taskManagerDbContext.TaskLists
            .AnyAsync(tl => tl.TaskListName == taskListName, cancellationToken);

        if (taskListStatus)
            throw new ConflictException("TaskList already exists!");
    }

    private static TaskList CreateTaskList(string taskListName, int currentUser)
    {
        return new TaskList
        {
            TaskListName = taskListName,
            CreatorId = currentUser,
            CreationDate = DateTime.UtcNow
        };
    }
}
