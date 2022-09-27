using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LevelUp.Application.Questions.Queries.GetQuestionById;

public record GetQuestionByIdQuery(long Id) : IRequest<QuestionEntity>;

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionEntity>
{
    private readonly ILogger<GetQuestionByIdQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetQuestionByIdQueryHandler(ILogger<GetQuestionByIdQueryHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<QuestionEntity> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.QuestionRepository.GetFirstOrDefaultAsync(u => u.Id == request.Id);
    }
}
