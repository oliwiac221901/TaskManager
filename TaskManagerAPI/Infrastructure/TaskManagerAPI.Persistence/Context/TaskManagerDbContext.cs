using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Entities.UserManage;
using TaskManagerAPI.Persistence.EntityConfigurations.UsersConfigurations;

namespace TaskManagerAPI.Persistence.Context
{
	public class TaskManagerDbContext : DbContext
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
}
