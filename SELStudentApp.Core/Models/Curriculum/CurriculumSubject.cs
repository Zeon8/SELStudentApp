using System.Text.Json.Serialization;
using SELStudentApp.Core.JsonConverters;

namespace SELStudentApp.Core.Models.Curriculum;

public record CurriculumSubject
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Department { get; init; }

    public double Credits { get; init; }

    public int Hours { get; init; }

    public required string Type { get; init; }

    [JsonConverter(typeof(PerformanceConverter))]
    public Performance? Performance { get; init; }
}
