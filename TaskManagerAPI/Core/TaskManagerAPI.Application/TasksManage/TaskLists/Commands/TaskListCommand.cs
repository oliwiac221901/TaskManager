using MediatR;
using TaskManagerAPI.Application.Dtos.TasksManage;

namespace TaskManagerAPI.Application.TasksManage.TaskLists.Commands;

public class TaskListCommand : IRequest<int>
{
    public TaskListDto TaskListDto { get; set; }
}
