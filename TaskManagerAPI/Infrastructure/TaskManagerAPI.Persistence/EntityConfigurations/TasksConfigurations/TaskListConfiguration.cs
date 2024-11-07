using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerAPI.Domain.Entities.TasksManage;

namespace TaskManagerAPI.Persistence.EntityConfigurations.TasksConfigurations;

public class TaskListConfiguration : IEntityTypeConfiguration<TaskList>
{
    public void Configure(EntityTypeBuilder<TaskList> builder)
    {
        builder.HasKey(tl => tl.TaskListId);

        builder.Property(tl => tl.TaskListName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(tl => tl.CreatorId)
            .IsRequired();

        builder.Property(tl => tl.CreationDate)
            .IsRequired();
    }
}
