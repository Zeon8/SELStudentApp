using System.Text.Json.Serialization;

namespace SELStudentApp.Core.Models;

public record SELScheduleItem
{
    public int Id { get; init; }
    public int Uid { get; init; }

    [JsonPropertyName("individual_plan_id")]
    public int? IndividualPlanId { get; init; }

    [JsonPropertyName("teacher_id")]
    public int? TeacherId { get; init; }

    [JsonPropertyName("predmet_id")]
    public int? PredmetId { get; init; }

    [JsonPropertyName("pidgrupa_id")]
    public int? PidgrupaId { get; init; }

    public int Day { get; init; }
    public int? Weekly { get; init; }

    [JsonPropertyName("date_w")]
    public int? DateW { get; init; }

    public bool? Main { get; init; }
    public string? Year { get; init; }

    [JsonPropertyName("aud_id")]
    public int? AudId { get; init; }

    [JsonPropertyName("para")]
    public int ParaNumber { get; init; }

    public string? Date { get; init; }

    [JsonPropertyName("type_hours")]
    public string? TypeHours { get; init; }

    public int? Mountly { get; init; }
    public int? Hours { get; init; }

    [JsonPropertyName("type_lesson_id")]
    public ClassType? ClassType { get; init; }

    public required SELTeacher Teacher { get; init; }
    public required SELSubject Subject { get; init; }
    public SELRoom? Room { get; init; }

    [JsonPropertyName("zoom_meeting")]
    public SELZoomMeeting? ZoomMeeting { get; init; }

    [JsonPropertyName("is_remote")]
    public string? IsRemote { get; init; }

    [JsonPropertyName("theme_name")]
    public string? ThemeName { get; init; }

    [JsonPropertyName("additional_materials")]
    public string? AdditionalMaterials { get; init; }
    public string? Homework { get; init; }
    public string? Notes { get; init; }
    public int? Semester { get; init; }

    public int CurrentSemester => Semester ?? 1;

    public bool IsOnline => IsRemote == "1" || ZoomMeeting is not null;
}
