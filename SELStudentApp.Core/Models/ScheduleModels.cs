using System.Text.Json.Serialization;
using SELStudentApp.Core.Models;

namespace SELStudentApp.Models;

public record SELScheduleResponse
{
    [JsonPropertyName("week_start")]
    public required string WeekStart { get; init; }

    [JsonPropertyName("week_end")]
    public required string WeekEnd { get; init; }

    public required IReadOnlyDictionary<string, IEnumerable<SELScheduleItem>> Schedule { get; init; }

    public string? Message { get; init; }
}

public record ScheduleData(IEnumerable<SELScheduleItem> Data)
{
    public string? Message { get; init; }
}
