using Microsoft.UI.Xaml.Data;
using SELStudentApp.Core.Services;
using SELStudentApp.ViewModels;
using Uno.Logging;

namespace SELStudentApp.Presentation;

[Bindable]
public partial class LoginViewModel : ObservableObject
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string? _errorMessage;

    private readonly INavigator _navigator;
    private readonly IAuthService _authService;
    private readonly ILogger<LoginViewModel> _logger;

    public LoginViewModel(
        INavigator navigator,
        IAuthService authService,
        ILogger<LoginViewModel> logger)
    {
        _navigator = navigator;
        _authService = authService;
        _logger = logger;
    }


    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            return;

        IsLoading = true;

        try
        {
            bool success = await _authService.LoginAsync(Email, Password);
            if (success)
            {
                await _navigator.NavigateViewModelAsync<DashboardViewModel>(this, qualifier: Qualifiers.ClearBackStack);
            }
            else
                ErrorMessage = "Неправильний логін або пароль.";
        }
        catch (TaskCanceledException exception)
        {
            _logger.Error("Connection cancelled.", exception);
            ErrorMessage = "Відсутнє з'єдання з сервером.";
        }
        catch (HttpRequestException exception)
        {
            _logger.Error("Login failed", exception);
            ErrorMessage = "Виникла помилка під час з'єднання з сервером.";
        }

        IsLoading = false;
    }
}
