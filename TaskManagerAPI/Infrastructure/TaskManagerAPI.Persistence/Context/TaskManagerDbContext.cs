using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Domain.Entities.TasksManage;
using TaskManagerAPI.Domain.Entities.UserManage;
using TaskManagerAPI.Persistence.EntityConfigurations.TasksConfigurations;
using TaskManagerAPI.Persistence.EntityConfigurations.UsersConfigurations;

namespace TaskManagerAPI.Persistence.Context;

public class TaskManagerDbContext : DbContext, ITaskManagerDbContext
{
	public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TaskListConfiguration());

        base.OnModelCreating(modelBuilder);
    }
 }
