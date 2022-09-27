using LevelUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LevelUp.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private const int _numerOfDevelopersToGenerate = 10;

    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        await AddUsers();
        await AddQuestionsAndOptions();
    }

    private async Task AddUsers()
    {
        if (!_context.Users.Any())
        {
            var mangerPerson = new Bogus.Person();
            var manager = new UserEntity()
            {

                FirstName = mangerPerson.FirstName,
                LastName = mangerPerson.LastName,
                FullName = mangerPerson.FullName,
                Email = mangerPerson.Email,
                Avatar = mangerPerson.Avatar,
                JobFunctionName = "Manager",
                CreatedAt = DateTime.UtcNow,
            };

            await _context.Users.AddAsync(manager);
            await _context.SaveChangesAsync();

            var users = new List<UserEntity>();

            for (int i = 0; i < _numerOfDevelopersToGenerate; i++)
            {
                var person = new Bogus.Person();

                var user = new UserEntity()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    FullName = person.FullName,
                    Email = person.Email,
                    Avatar = person.Avatar,
                    JobFunctionName = "Developer",
                    ManagerId = _context.Users.First(_ => _.JobFunctionName == "Manager").Id,
                    CreatedAt = DateTime.UtcNow
                };

                users.Add(user);
            }

            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }
    }

    private async Task AddQuestionsAndOptions()
    {
        //    var entryOption = new List<QuestionOptionEntity>() 
        //    {
        //        new QuestionOptionEntity()
        //        {

        //        }
        //    }
        //    var question = new QuestionEntity("Do you want to start a carrier as software developer?",
        //        new List<QuestionOptionEntity>() { QuestionOptionEntity})
        //}
    }
}
