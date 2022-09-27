using LevelUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<UserEntity> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
