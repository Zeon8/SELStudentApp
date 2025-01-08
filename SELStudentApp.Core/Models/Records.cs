using System.Text.Json.Serialization;

namespace SELStudentApp.Core.Models;

public record SELSubject(int Id, string Name)
{
    [JsonPropertyName("short_name")]
    public string? ShortName { get; init; }
}

public record SELTeacher(int Id)
{
    [JsonPropertyName("t_name")]
    public string? FullName { get; init; }

    [JsonPropertyName("short_t_name")]
    public string? ShortName { get; init; }
}

public record SELRoom(int Id, string Name, int? Floor)
{
    [JsonPropertyName("case_number")]
    public int? CaseNumber { get; init; }
}
