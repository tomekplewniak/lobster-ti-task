using LevelUp.Domain.Common;

namespace LevelUp.Domain.Entities;

public class QuestionOptionEntity : BaseEntity
{
    public long QuestionId { get; set; }

    public virtual QuestionEntity Question { get; set; }

    public string Label { get; set; }

    public float Value { get; set; }

    public long? NextQuestionId { get; set; }

    public virtual QuestionEntity NextQuestion { get; set; }
}
