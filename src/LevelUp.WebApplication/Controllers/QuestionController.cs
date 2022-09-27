using AutoMapper;
using LevelUp.Application.Questions.Queries.GetQuestionById;
using LevelUp.Shared.DtoModels;
using LevelUp.WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.WebApplication.Controllers;

[ApiController]
[Route("questions")]
public class QuestionController : BaseApiController
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;

    public QuestionController(ILogger<UserController> logger,
        IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<QuestionDto> GetQuestionById(long id)
    {
        var information = "Request question by id";
        _logger.LogInformation("{Name} | {Message} | {UserId} ",
            nameof(GetQuestionById),
            information,
            id);
        var user = await Mediator.Send(new GetQuestionByIdQuery(id));

        return _mapper.Map<QuestionDto>(user);
    }
}
