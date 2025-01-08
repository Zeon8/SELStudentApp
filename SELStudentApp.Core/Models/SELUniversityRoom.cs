using System.Text.Json.Serialization;
using SELStudentApp.Models;

namespace SELStudentApp.Core.Models;

public record SELUniversityRoom
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("case_number")]
    public int CaseNumber { get; init; }

    [JsonPropertyName("floor")]
    public int Floor { get; init; }

    [JsonPropertyName("class_room_area")]
    public double? ClassRoomArea { get; init; }

    [JsonPropertyName("count_seats_max")]
    public int? CountSeatsMax { get; init; }

    [JsonPropertyName("count_seats_min")]
    public int? CountSeatsMin { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("aud_type_id")]
    public int AudTypeId { get; init; }

    [JsonPropertyName("proektor")]
    public int Proektor { get; init; }

    [JsonPropertyName("schedules")]
    public required IEnumerable<SELRoomSchedule> Schedules { get; init; }
}
