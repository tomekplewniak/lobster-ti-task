using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;

namespace LevelUp.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericAsyncRepository<UserEntity>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
