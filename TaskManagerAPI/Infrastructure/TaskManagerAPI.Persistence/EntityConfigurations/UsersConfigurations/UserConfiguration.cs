using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Persistence.EntityConfigurations.UsersConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(r => r.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(r => r.CreatedAt)
                .IsRequired();
        }
    }
}
