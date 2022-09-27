using LevelUp.Domain.Common;

namespace LevelUp.Domain.Entities;

public class QuestionResponseEntity : BaseEntity
{
    public QuestionResponseEntity(QuestionEntity question, QuestionOptionEntity selectedOption)
    {
        Question = question;
        SelectedOption = selectedOption;
    }

    public Guid UserId { get; set; }

    public long QuestionId { get; set; }

    public virtual QuestionEntity Question { get; set; }

    public long SelectedOptionId { get; set; }

    public virtual QuestionOptionEntity SelectedOption { get; set; }
}
