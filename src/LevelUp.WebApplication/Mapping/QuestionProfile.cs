using AutoMapper;
using LevelUp.Domain.Entities;
using LevelUp.Shared.DtoModels;

namespace LevelUp.WebApplication.Mapping
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionDto, QuestionEntity>()
                .ForMember(entity => entity.DomainEvents, opts => opts.Ignore());
            CreateMap<QuestionEntity, QuestionDto>();
        }
    }
}
