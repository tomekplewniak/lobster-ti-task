using AutoMapper;
using LevelUp.Application.Users.Commands.AddUser;
using LevelUp.Application.Users.Commands.DeleteUserById;
using LevelUp.Application.Users.Queries.GetAllUsers;
using LevelUp.Application.Users.Queries.GetUserById;
using LevelUp.Application.Users.Queries.SearchUserByName;
using LevelUp.Domain.DtoModels.User;
using LevelUp.WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.WebApplication.Controllers;

[ApiController]
[Route("users")]
public class UserController : BaseApiController
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger,
        IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        var information = "Request all users.";
        _logger.LogInformation("{Name} | {Message} | ",
            nameof(GetAllUsers), information);
        var users = await Mediator.Send(new GetAllUsersQuery());

        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<UserDto> GetUserById(long id)
    {
        var information = "Request user by id";
        _logger.LogInformation("{Name} | {Message} | {UserId} ",
            nameof(GetUserById),
            information,
            id);
        var user = await Mediator.Send(new GetUserByIdQuery(id));

        return _mapper.Map<UserDto>(user);
    }

    [HttpPost]
    public async Task<UserDto> AddUser(AddUserDto newUser)
    {
        var information = "Add new user.";
        _logger.LogInformation("{Name} | {Message} | ",
            nameof(AddUser), information);

        var addUser = _mapper.Map<AddUserCommand>(newUser);

        var user = await Mediator.Send(addUser);

        return _mapper.Map<UserDto>(user);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteUserById(long id)
    {
        var information = "Delete user by id";
        _logger.LogInformation("{Name} | {Message} | {UserId} ",
            nameof(GetUserById),
            information,
            id);
        var user = await Mediator.Send(new DeleteUserByIdCommand(id));
    }

    [HttpPost]
    [Route("search")]
    public async Task<IEnumerable<UserDto>> SearchUserByName([FromBody] string name)
    {
        var users = await Mediator.Send(new SearchUserByNameQuery(name));
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}
