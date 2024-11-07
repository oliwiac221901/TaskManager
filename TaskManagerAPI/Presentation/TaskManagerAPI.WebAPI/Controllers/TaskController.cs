using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Dtos.TasksManage;
using TaskManagerAPI.Application.TasksManage.TaskLists.Commands;

namespace TaskManagerAPI.WebAPI.Controllers;

[Route("/api/tasks")]
[ApiController]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Authorize]
public class TaskController : BaseController
{
    [HttpPost("taskLists")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateTaskList([FromBody] TaskListDto taskListDto)
    {
        var command = new TaskListCommand
        {
            TaskListDto = taskListDto
        };

        var result = await Mediator.Send(command);
        return Created(string.Empty, result);
    }
}
