using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Entities.UserManage;

namespace TaskManagerAPI.Application.Common.Interfaces
{
    public interface ITaskManagerDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
