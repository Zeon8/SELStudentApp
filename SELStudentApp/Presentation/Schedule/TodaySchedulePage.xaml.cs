using SELStudentApp.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SELStudentApp.Presentation.Schedule;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class TodaySchedulePage : Page
{
    public TodaySchedulePage()
    {
        this.InitializeComponent();
    }

    private void Page_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (DataContext is ScheduleViewModel viewModel)
            viewModel.LoadTodayScheduleCommand.Execute(null);
    }
}
