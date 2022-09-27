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
        var entryQuestion = new QuestionEntity()
        {
            Id = 1,
            Text = "Do you want to start a carrier as software developer?",
            Sequence = 1
        };

        var entryQuestionOptions = new List<QuestionOptionEntity>()
            {
                new QuestionOptionEntity()
                {
                    Question = entryQuestion,
                    Label = "No",
                    Value = 0
                },
                new QuestionOptionEntity()
                {
                    Question = entryQuestion,
                    Label = "Yes",
                    Value = 1
                }
            };

        await _context.Questions.AddAsync(entryQuestion);
        await _context.SaveChangesAsync();

        var juniorQuestion = new QuestionEntity()
        {
            Id = 2,
            Text = "So you select to be developer. You want still work as dev?",
            Sequence = 2
        };

        var entryOption = entryQuestionOptions.Single(_ => _.Label == "Yes");
        entryOption.NextQuestionId = 2;
        _context.QuestionOptions.Update(entryOption);

        var juniorQuestionOptions = new List<QuestionOptionEntity>()
            {
                new QuestionOptionEntity()
                {
                    Question = juniorQuestion,
                    Label = "No",
                    Value = 0
                },
                new QuestionOptionEntity()
                {
                    Question = juniorQuestion,
                    Label = "Yes",
                    Value = 1
                }
            };

        await _context.Questions.AddAsync(juniorQuestion);
        await _context.SaveChangesAsync();

        var midQuestion = new QuestionEntity()
        {
            Id = 3,
            Text = "Still in codding... Do you still want continue work?",
            Sequence = 3
        };

        var juniorOption = juniorQuestionOptions.Single(_ => _.Label == "Yes");
        juniorOption.NextQuestionId = 3;
        _context.QuestionOptions.Update(juniorOption);

        var midQuestionOptions = new List<QuestionOptionEntity>()
            {
                new QuestionOptionEntity()
                {
                    Question = midQuestion,
                    Label = "No",
                    Value = 0
                },
                new QuestionOptionEntity()
                {
                    Question = midQuestion,
                    Label = "Yes",
                    Value = 1
                }
            };

        await _context.Questions.AddAsync(midQuestion);
        await _context.SaveChangesAsync();

        var seniorQuestion = new QuestionEntity()
        {
            Id = 4,
            Text = "Good work... Do you want became lead dev or maybe junior project manager?",
            Sequence = 4
        };

        var midOption = midQuestionOptions.Single(_ => _.Label == "Yes");
        midOption.NextQuestionId = 4;
        _context.QuestionOptions.Update(midOption);

        var seniorQuestionOptions = new List<QuestionOptionEntity>()
            {
                new QuestionOptionEntity()
                {
                    Question = seniorQuestion,
                    Label = "Senior Developer",
                    Value = 0
                },
                new QuestionOptionEntity()
                {
                    Question = seniorQuestion,
                    Label = "Junior Project Manager",
                    Value = 1
                }
            };

        await _context.Questions.AddAsync(seniorQuestion);
        await _context.SaveChangesAsync();

        var leadQuestion = new QuestionEntity()
        {
            Id = 5,
            Text = "Amazing you are lead developer... Do you want became Architect or Project Manager?",
            Sequence = 5
        };

        var projectQuestion = new QuestionEntity()
        {
            Id = 6,
            Text = "Ahh.. So you selected to be Project Manager. This is still valid?",
            Sequence = 6
        };

        var seniorDevOption = seniorQuestionOptions.Single(_ => _.Label == "Senior Developer");
        seniorDevOption.NextQuestionId = 5;
        _context.QuestionOptions.Update(seniorDevOption);

        var seniorProjectOption = seniorQuestionOptions.Single(_ => _.Label == "Junior Project Manager");
        seniorProjectOption.NextQuestionId = 6;
        _context.QuestionOptions.Update(seniorProjectOption);

        var leadQuestionOptions = new List<QuestionOptionEntity>()
            {
                new QuestionOptionEntity()
                {
                    Question = seniorQuestion,
                    Label = "Lead Software Enginner",
                    Value = 0
                },
                new QuestionOptionEntity()
                {
                    Question = seniorQuestion,
                    Label = "Project Manager",
                    Value = 1
                }
            };

        await _context.Questions.AddAsync(leadQuestion);
        await _context.Questions.AddAsync(projectQuestion);

        await _context.SaveChangesAsync();
    }
}
