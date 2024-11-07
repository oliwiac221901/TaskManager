using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Entities.TasksManage;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Application.Common.Interfaces;

public interface ITaskManagerDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<TaskList> TaskLists { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
