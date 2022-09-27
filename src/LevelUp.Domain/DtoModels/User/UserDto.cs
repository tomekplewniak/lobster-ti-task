namespace LevelUp.Domain.DtoModels.User;

public class UserDto
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public string? LastModifiedBy { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Avatar { get; set; }

    public string? JobFunctionName { get; set; }

    public long? ManagerId { get; set; }
}
