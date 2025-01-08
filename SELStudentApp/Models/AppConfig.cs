namespace SELStudentApp.Models;

public record AppConfig
{
    public string? Environment { get; init; }

    public string? ServerUrl { get; init; }
}
