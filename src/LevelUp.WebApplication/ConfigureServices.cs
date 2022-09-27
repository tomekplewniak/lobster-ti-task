using LevelUp.Application.Common.Interfaces;
using LevelUp.WebApplication.Services;

namespace LevelUp.WebApplication;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();

        return services;
    }
}
