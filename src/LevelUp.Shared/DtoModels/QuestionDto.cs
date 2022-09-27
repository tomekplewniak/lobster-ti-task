namespace LevelUp.Shared.DtoModels;

public class QuestionDto
{
    public long Id { get; set; }

    public string Text { get; set; }

    public uint Sequence { get; set; }

    public List<QuestionOptionDto> Options { get; set; }
}
