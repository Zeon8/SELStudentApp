using System.Text.Json.Serialization;

namespace SELStudentApp.Core.Models;

public record SELZoomMeeting
{
    public int Id { get; init; }

    [JsonPropertyName("timetable_class_id")]
    public int TimetableClassId { get; init; }

    [JsonPropertyName("zoom_link")]
    public required string Link { get; init; }

    [JsonPropertyName("meeting_id")]
    public required string MeetingId { get; init; }

    [JsonPropertyName("passcode")]
    public required string Password { get; init; }

    [JsonPropertyName("host_email")]
    public required string HostEmail { get; init; }

    [JsonPropertyName("additional_info")]
    public string? AdditionalInfo { get; init; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; init; }
}
