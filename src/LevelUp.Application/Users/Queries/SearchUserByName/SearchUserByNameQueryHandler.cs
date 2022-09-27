using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUp.Application.Common.Interfaces;
using LevelUp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LevelUp.Application.Users.Queries.SearchUserByName;

public record SearchUserByNameQuery(string Name) : IRequest<IEnumerable<UserEntity>>;

public class SearchUserByNameQueryHandler : IRequestHandler<SearchUserByNameQuery, IEnumerable<UserEntity>>
{
    private readonly ILogger<SearchUserByNameQueryHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public SearchUserByNameQueryHandler(ILogger<SearchUserByNameQueryHandler> logger,
            IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserEntity>> Handle(SearchUserByNameQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetAsync(_ => _.FullName.StartsWith(request.Name));
    }
}
