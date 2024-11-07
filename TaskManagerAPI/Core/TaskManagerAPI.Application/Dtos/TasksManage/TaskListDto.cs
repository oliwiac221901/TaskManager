namespace TaskManagerAPI.Application.Dtos.TasksManage;

public class TaskListDto
{
    public string TaskListName { get; set; }
    public int CreatorId { get; set; }
    public DateTime CreationDate { get; set; }
}
