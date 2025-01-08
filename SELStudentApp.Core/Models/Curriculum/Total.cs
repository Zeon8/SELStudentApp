using System.Text.Json.Serialization;

namespace SELStudentApp.Core.Models.Curriculum;
public record Total(string Previous, string Current, string Ects, int Rating);

public record Score(string Topic)
{
    [JsonPropertyName("score")]
    public double Value { get; init; }
}

public record Performance(Part Part1, Part Part2, Total Total);

public record CurriculumSemester(int Id, string Name, string Year, IEnumerable<CurriculumSubject> Subjects);

public record Curriculum(IEnumerable<CurriculumSemester> Semesters, double TotalCredits)
{
    public int TotalHours => Semesters
        .SelectMany(s => s.Subjects)
        .Select(s => s.Hours)
        .Sum();
}
