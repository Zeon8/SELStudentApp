using Microsoft.UI.Xaml.Data;
using SELStudentApp.Core.Models;
using SELStudentApp.Core.Services;

namespace SELStudentApp.ViewModels;

[Bindable]
public partial class DashboardViewModel : DataLoadingViewModel
{
    [ObservableProperty]
    private IEnumerable<ScheduleItemViewModel>? _todayClasses;

    [ObservableProperty]
    private ScheduleItemViewModel? _nextClass;

    private readonly IDashboardService _dashboardService;
    private readonly ILogger<DashboardViewModel> _logger;
    private readonly ISettings _settings;
    private readonly INavigator _navigator;

    public DashboardViewModel(IDashboardService dashboardService,
        ILogger<DashboardViewModel> logger,
        ISettings settings,
        INavigator navigator)
    {
        _dashboardService = dashboardService;
        _logger = logger;
        _settings = settings;
        _navigator = navigator;
    }

    [RelayCommand]
    private async Task Load()
    {
        DashboardData? data = await HandleHttpExceptions(_dashboardService.GetDashboardData(), _logger);
        if (data is not null)
        {
            TodayClasses = data.TodayClasses
                // .Take(4) // Temporary limit, because test server might return 64 classes
                .Select(c => new ScheduleItemViewModel(c));

            if (data.NextClass is not null)
                NextClass = new ScheduleItemViewModel(data.NextClass);

            Message = data.Message;
            if (string.IsNullOrEmpty(Message))
                Message = null;
        }
    }

    [RelayCommand]
    private async Task Logout()
    {
        _settings.Clear();
        await _navigator.NavigateViewModelAsync<LoginViewModel>(this, qualifier: Qualifiers.ClearBackStack);
    }
}
