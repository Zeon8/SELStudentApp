namespace SELStudentApp.Core.Models.Curriculum;
public record Part
{
    public required IEnumerable<Score> Scores { get; init; }

    public int Presence { get; init; }

    public int Presentation { get; init; }

    public int Scientific { get; init; }

    public int Additional { get; init; }

    public required string Sum { get; init; }

    public required string Mark { get; init; }

    public string? Type { get; init; }

}
