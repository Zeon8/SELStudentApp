using System.Text.Json.Serialization;

namespace SELStudentApp.Models;

public record SELRoomSchedule
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("uid")]
    public int? Uid { get; init; }

    [JsonPropertyName("time_add_cron")]
    public string? TimeAddCron { get; init; }

    [JsonPropertyName("classes_left_cron")]
    public string? ClassesLeftCron { get; init; }

    [JsonPropertyName("approximate")]
    public string? Approximate { get; init; }

    [JsonPropertyName("individual_plan_id")]
    public int? IndividualPlanId { get; init; }

    [JsonPropertyName("teacher_id")]
    public int TeacherId { get; init; }

    [JsonPropertyName("predmet_id")]
    public int PredmetId { get; init; }

    [JsonPropertyName("grupa_id_list")]
    public required string GrupaIdList { get; init; }

    [JsonPropertyName("pidgrupa_id")]
    public int? PidgrupaId { get; init; }

    [JsonPropertyName("day")]
    public int? Day { get; init; }

    [JsonPropertyName("weekly")]
    public int? Weekly { get; init; }

    [JsonPropertyName("date_w")]
    public string? DateW { get; init; }

    [JsonPropertyName("main")]
    public bool Main { get; init; }

    [JsonPropertyName("year")]
    public int? Year { get; init; }

    [JsonPropertyName("aud_id")]
    public int AudId { get; init; }

    [JsonPropertyName("para")]
    public int? Para { get; init; }

    [JsonPropertyName("date")]
    public required string Date { get; init; }

    [JsonPropertyName("type_hours")]
    public string? TypeHours { get; init; }

    [JsonPropertyName("mountly")]
    public string? Mountly { get; init; }

    [JsonPropertyName("hours")]
    public int Hours { get; init; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    [JsonPropertyName("type_lesson_id")]
    public int? TypeLessonId { get; init; }

    [JsonPropertyName("error_summary")]
    public string? ErrorSummary { get; init; }

    [JsonPropertyName("para_list")]
    public string? ParaList { get; init; }
}
