using AutoMapper;
using LevelUp.Application.Users.Commands.AddUser;
using LevelUp.Domain.DtoModels.User;
using LevelUp.Domain.Entities;

namespace LevelUp.WebApplication.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserEntity>()
            .ForMember(entity => entity.DomainEvents, opts => opts.Ignore());
        CreateMap<UserEntity, UserDto>();

        CreateMap<AddUserDto, AddUserCommand>();
        CreateMap<AddUserCommand, AddUserDto>();
    }
}
