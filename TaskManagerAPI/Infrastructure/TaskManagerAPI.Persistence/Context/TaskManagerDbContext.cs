using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Domain.Entities.UserManage;
using TaskManagerAPI.Persistence.EntityConfigurations.UsersConfigurations;

namespace TaskManagerAPI.Persistence.Context;

public class TaskManagerDbContext : DbContext, ITaskManagerDbContext
{
	public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
 }
