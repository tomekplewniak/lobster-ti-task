using LevelUp.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace LevelUp.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ILogger<UnitOfWork> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IUserRepository _userRepository;

    public UnitOfWork(ILogger<UnitOfWork> logger,
            ApplicationDbContext context,
            IUserRepository userRepository)
    {
        _logger = logger;
        _context = context;
        _userRepository = userRepository;
    }

    public IUserRepository UserRepository => _userRepository;

    public async Task SaveAsync()
    {
        var savedCount = await _context.SaveChangesAsync();
        _logger.LogDebug("Saved {count} entities to database", savedCount);
    }

    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true).Wait();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    private async Task Dispose(bool disposing)
    {
        if (!_disposed && disposing)
            await _context.DisposeAsync();

        _disposed = true;
    }
}
