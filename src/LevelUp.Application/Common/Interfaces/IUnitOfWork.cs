namespace LevelUp.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IUserRepository UserRepository { get; }

    IQuestionRepository QuestionRepository { get; }

    Task SaveAsync();
}
