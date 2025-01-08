using System.Text.Json.Serialization;

namespace SELStudentApp.Core.Models;

public record class SELStudent
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }

    [JsonPropertyName("tg_username")]
    public string? TelegramUsername { get; init; }

    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; init; }

    public int Status { get; init; }

    [JsonPropertyName("logged_at")]
    public int? LoggedAt { get; init; }

    [JsonPropertyName("last_visit")]
    public int? LastVisit { get; init; }

    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}
