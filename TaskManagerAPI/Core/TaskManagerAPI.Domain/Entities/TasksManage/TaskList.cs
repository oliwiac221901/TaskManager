namespace TaskManagerAPI.Domain.Entities.TasksManage;

public class TaskList
{
    public int TaskListId { get; set; }
    public string TaskListName { get; set; }
    public int CreatorId { get; set; }
    public DateTime CreationDate { get; set; }
}
