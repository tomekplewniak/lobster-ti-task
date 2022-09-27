using MediatR;

namespace LevelUp.Application.Users.Commands.DeleteUserById;

public record DeleteUserByIdCommand(long Id) : IRequest
{
}
