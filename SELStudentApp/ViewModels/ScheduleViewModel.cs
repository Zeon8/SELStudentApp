using SELStudentApp.Core.Models;
using SELStudentApp.Core.Services;

namespace SELStudentApp.ViewModels;

public partial class ScheduleViewModel : DataLoadingViewModel
{
    [ObservableProperty]
    private string? _message;

    [ObservableProperty]
    private IEnumerable<ScheduleItemViewModel>? _scheduleItems;

    private readonly IScheduleService _scheduleService;
    private readonly ILogger<ScheduleViewModel> _logger;
    private readonly INavigator _navigation;

    public ScheduleViewModel(IScheduleService scheduleService, ILogger<ScheduleViewModel> logger,
        INavigator navigation)
    {
        _scheduleService = scheduleService;
        _logger = logger;
        _navigation = navigation;
    }

    [RelayCommand]
    private Task LoadTodaySchedule() => LoadSchedule(DateTime.Today);

    public async Task LoadSchedule(DateTime date)
    {
        ScheduleItems = null;
        var data = await HandleHttpExceptions(_scheduleService.GetSchedule(date), _logger);
        if (data is not null)
        {
            ScheduleItems = data.Data
                // .Take(4) // Temporary limit, because test server might return 64 classes
                .Select(i => new ScheduleItemViewModel(i));

            Message = data.Message;
            if (string.IsNullOrEmpty(Message))
                Message = null;
        }
    }

    [RelayCommand]
    public async Task ViewClassDetail(SELScheduleItem item)
    {
        await _navigation.NavigateViewModelAsync<ClassDetailViewModel>(this, data: item);
    }
}
