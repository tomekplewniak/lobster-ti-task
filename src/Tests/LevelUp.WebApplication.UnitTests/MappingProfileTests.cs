using AutoMapper;
using LevelUp.WebApplication.Mapping;

namespace LevelUp.WebApplication.UnitTests;

public class MappingProfileTests
{
    [Fact]
    public void ValidateUserProfileMappingConfigurationTest()
    {
        MapperConfiguration mapperConfig = new MapperConfiguration(
        cfg =>
        {
            cfg.AddProfile(new UserProfile());
            cfg.AddProfile(new QuestionProfile());
        });

        IMapper mapper = new Mapper(mapperConfig);

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
