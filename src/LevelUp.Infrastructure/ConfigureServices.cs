using LevelUp.Application.Common.Interfaces;
using LevelUp.Infrastructure.Interceptors;
using LevelUp.Infrastructure.Persistence;
using LevelUp.Infrastructure.Persistence.Repositories;
using LevelUp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LevelUp.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient<IUserRepository, UserRepository>();

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("FeedbackDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .EnableSensitiveDataLogging()
                .UseSnakeCaseNamingConvention());
        }

        return services;
    }
}
