using LevelUp.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LevelUp.Application.Users.Commands.DeleteUserById;

public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Unit>
{
    private readonly ILogger<DeleteUserByIdCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserByIdCommandHandler(ILogger<DeleteUserByIdCommandHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.UserRepository.Delete(request.Id);
        await _unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
