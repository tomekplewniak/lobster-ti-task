using LevelUp.Domain.Common;

namespace LevelUp.Domain.Entities;

public class UserEntity : BaseAuditableEntity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Avatar { get; set; }

    public string? JobFunctionName { get; set; }

    public long? ManagerId { get; set; }
}
