using Uno.Logging;

namespace SELStudentApp.ViewModels;
public partial class DataLoadingViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string? _errorMessage;

    [ObservableProperty]
    private string? _message;

    public async Task<T?> HandleHttpExceptions<T>(Task<T> task, ILogger logger)
    {
        IsLoading = true;
        T? data = default;
        try
        {
            data = await task;
            if (data is null)
            {
                logger.Error("Got null data.");
                ErrorMessage = "Виникла невідома помилка під час отримання даних.";
            }
        }
        catch (TaskCanceledException exception)
        {
            logger.Error("Connection cancelled.", exception);
            ErrorMessage = "Відсутнє з'єдання з сервером.";
        }
        catch (HttpRequestException exception)
        {
            logger.Error("Failed to get data.", exception);
            ErrorMessage = "Виникла помилка під час з'єднання з сервером.";
        }
        IsLoading = false;
        return data;
    }
}
