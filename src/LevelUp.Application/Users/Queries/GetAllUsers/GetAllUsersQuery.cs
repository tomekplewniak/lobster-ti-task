using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LevelUp.Application.Users.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<IEnumerable<UserEntity>>;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
{
    private readonly ILogger<GetAllUsersQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;


    public GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetAsync();
    }
}
