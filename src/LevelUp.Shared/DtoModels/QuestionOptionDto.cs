namespace LevelUp.Shared.DtoModels;

public class QuestionOptionDto
{
    public long Id { get; set; }

    public long QuestionId { get; set; }

    public string Label { get; set; }

    public float Value { get; set; }

    public long? NextQuestionId { get; set; }
}
