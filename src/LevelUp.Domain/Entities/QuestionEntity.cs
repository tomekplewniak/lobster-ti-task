using LevelUp.Domain.Common;

namespace LevelUp.Domain.Entities;

public class QuestionEntity : BaseEntity
{
    public string Text { get; set; }

    public uint Sequence { get; set; }

    public virtual ICollection<QuestionOptionEntity> Options { get; set; }
}
