using SELStudentApp.ViewModels;

namespace SELStudentApp.Presentation.Schedule;

public sealed partial class SemesterSchedulePage : Page
{
    private ScheduleViewModel ViewModel => (ScheduleViewModel)DataContext;

    public SemesterSchedulePage()
    {
        this.InitializeComponent();
    }

    private async Task LoadSchedule()
    {
        if (Calendar.SelectedDates.Count > 0)
        {
            DateTimeOffset date = Calendar.SelectedDates[0];
            await ViewModel.LoadSchedule(date.DateTime);
        }
    }

    private async void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
    {
        await LoadSchedule();
    }

    private async void Button_Click(object sender, RoutedEventArgs e) => await LoadSchedule();

    private async void Page_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (DataContext is null)
            return;

        Calendar.SelectedDates.Clear();
        Calendar.SelectedDates.Add(DateTimeOffset.Now);
        await LoadSchedule();
    }
}
