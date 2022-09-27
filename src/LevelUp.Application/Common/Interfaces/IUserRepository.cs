using LevelUp.Domain.Entities;

namespace LevelUp.Application.Common.Interfaces;

public interface IUserRepository : IAsyncRepository<UserEntity>
{
}
