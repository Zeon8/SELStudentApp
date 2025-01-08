using Windows.ApplicationModel.DataTransfer;

namespace SELStudentApp.ViewModels;

public partial class ClassDetailViewModel : ObservableObject
{
    public ScheduleItemViewModel Item { get; }

    public ClassDetailViewModel(ScheduleItemViewModel item)
        => Item = item;

    [RelayCommand]
    private void CopyToClipboard(string value)
    {
        var dataPackage = new DataPackage();
        dataPackage.SetText(value);
        Clipboard.SetContent(dataPackage);
    }
}
