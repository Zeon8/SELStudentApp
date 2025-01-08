using SELStudentApp.Core.Models.Curriculum;
using SELStudentApp.Core.Services;

namespace SELStudentApp.ViewModels;

public partial class CurriculumViewModel : DataLoadingViewModel
{
    public IEnumerable<SubjectViewModel>? Subjects => SelectedSemester?.Subjects
        .Take(2)
        .Select(s => new SubjectViewModel(s));

    [ObservableProperty]
    private Curriculum? _curriculum;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Subjects))]
    private CurriculumSemester? _selectedSemester;

    private readonly ICurriculumService _curriculumService;
    private readonly ILogger<CurriculumViewModel> _logger;

    public CurriculumViewModel(ICurriculumService curriculumService, ILogger<CurriculumViewModel> logger)
    {
        _curriculumService = curriculumService;
        _logger = logger;
    }

    [RelayCommand]
    private async Task Load()
    {
        Curriculum = await HandleHttpExceptions(_curriculumService.GetCurriculum(), _logger);
        SelectedSemester = Curriculum?.Semesters.First();
    }
}
