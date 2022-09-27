using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;

namespace LevelUp.Infrastructure.Persistence.Repositories;

public class QuestionRepository : GenericAsyncRepository<QuestionEntity>, IQuestionRepository
{
    public QuestionRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
