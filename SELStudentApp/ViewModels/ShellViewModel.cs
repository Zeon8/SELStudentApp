using Microsoft.UI.Xaml.Data;
using SELStudentApp.Core.Services;

namespace SELStudentApp.ViewModels;

[Bindable]
public class ShellViewModel
{
    private readonly ISettingsService _settingsService;
    private readonly INavigator _navigator;

    public ShellViewModel(INavigator navigator, ISettingsService settingsService)
    {
        _navigator = navigator;
        _settingsService = settingsService;
    }

    public async Task Navigate()
    {
        if (_settingsService.Load())
            await _navigator.NavigateViewModelAsync<DashboardViewModel>(this);
        else
            await _navigator.NavigateViewModelAsync<LoginViewModel>(this);
    }
}
