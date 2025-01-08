namespace SELStudentApp.Core.Models;

public record DashboardResponse(DashboardData Data);

public record DashboardData
{
    //[JsonPropertyName("today_classes")]
    public required IEnumerable<SELScheduleItem> TodayClasses { get; init; }

    //[JsonPropertyName("next_class")]
    public SELScheduleItem? NextClass { get; init; }

    //[JsonPropertyName("total_subjects")]
    public int TotalSubjects { get; init; }

    //[JsonPropertyName("current_semester")]
    public int CurrentSemester { get; init; }

    public string? Message { get; init; }
}
