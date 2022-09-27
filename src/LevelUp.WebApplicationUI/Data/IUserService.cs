using LevelUp.Domain.DtoModels.User;

namespace LevelUp.WebApplicationUI.Data;

public interface IUserService
{
    public Task<IEnumerable<UserDto>> GetAllUsers();

    public Task<UserDto> GetUserById(long id);

    public Task<IEnumerable<UserDto>> GetUserByNameSearch(string nameToSearch);
}
