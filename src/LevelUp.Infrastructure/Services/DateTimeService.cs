using LevelUp.Application.Common.Interfaces;

namespace LevelUp.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
