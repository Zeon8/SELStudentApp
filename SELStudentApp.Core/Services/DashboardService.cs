using SELStudentApp.Core.Models;

namespace SELStudentApp.Core.Services;

public class DashboardService : IDashboardService
{
    private readonly ISettingsService _settings;
    private readonly INetworkService _networkService;

    public DashboardService(ISettingsService settings, INetworkService networkService)
    {
        _settings = settings;
        _networkService = networkService;
    }

    public Task<DashboardData?> GetDashboardData()
    {
        var student = _settings.Student ?? throw new InvalidOperationException("Student is null.");
        return _networkService.Get<DashboardData>($"api/student-cabinet/dashboard/{student.Id}");
    }
}
