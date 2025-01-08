using SELStudentApp.Core.Models.Curriculum;

namespace SELStudentApp.Core.Services;

public class CurriculumService : ICurriculumService
{
    private readonly ISettingsService _settings;
    private readonly INetworkService _networkService;

    public CurriculumService(INetworkService networkService, ISettingsService settingsService)
    {
        _networkService = networkService;
        _settings = settingsService;
    }

    public Task<Curriculum?> GetCurriculum()
    {
        var student = _settings.Student ?? throw new InvalidOperationException("Student is null.");
        return _networkService.Get<Curriculum>($"api/student/curriculum/{student.Id}");
    }
}
