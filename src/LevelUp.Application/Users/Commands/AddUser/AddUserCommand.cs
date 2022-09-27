using LevelUp.Domain.Entities;
using MediatR;

namespace LevelUp.Application.Users.Commands.AddUser;

public record AddUserCommand(string FirstName,
    string LastName,
    string Email,
    string Avatar,
    string JobFunctionName,
    long ManagerId) : IRequest<UserEntity>
{
}
