using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LevelUp.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(long Id) : IRequest<UserEntity>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
{
    private readonly ILogger<GetUserByIdQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;


    public GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(u => u.Id == request.Id);
    }
}
