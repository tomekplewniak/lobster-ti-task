using LevelUp.Domain.Entities;

namespace LevelUp.Application.Common.Interfaces;

public interface IQuestionRepository : IAsyncRepository<QuestionEntity>
{
}
