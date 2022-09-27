using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LevelUp.Application.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserEntity>
{
    private const string TestUser = "Test User";

    private readonly ILogger<AddUserCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserCommandHandler(ILogger<AddUserCommandHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new UserEntity()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            FullName = $"{request.FirstName} {request.LastName}",
            Email = request.Email,
            Avatar = request.Avatar,
            JobFunctionName = request.JobFunctionName,
            ManagerId = request.ManagerId,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = TestUser
        };

        var addedUser = await _unitOfWork.UserRepository.AddAsync(newUser, cancellationToken);

        await _unitOfWork.SaveAsync();

        return addedUser.Entity;
    }
}
