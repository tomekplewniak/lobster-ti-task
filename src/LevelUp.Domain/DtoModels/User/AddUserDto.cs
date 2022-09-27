namespace LevelUp.Domain.DtoModels.User;

public class AddUserDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string? Avatar { get; set; }

    public string JobFunctionName { get; set; }

    public long? ManagerId { get; set; }
}
