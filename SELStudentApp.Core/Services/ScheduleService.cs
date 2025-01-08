using SELStudentApp.Models;

namespace SELStudentApp.Core.Services;
public class ScheduleService : IScheduleService
{
    private readonly INetworkService _networkService;
    private readonly ISettingsService _settings;

    public ScheduleService(INetworkService networkService, ISettingsService settings)
    {
        _networkService = networkService;
        _settings = settings;
    }

    public Task<ScheduleData?> GetSchedule(DateTime dateTime)
    {
        var student = _settings.Student ?? throw new InvalidOperationException("Student is null.");
        return _networkService.Get<ScheduleData>($"api/schedule/{student.Id}/{dateTime:yyyy-MM-dd}");
    }
}
