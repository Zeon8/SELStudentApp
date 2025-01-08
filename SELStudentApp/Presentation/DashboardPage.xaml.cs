using SELStudentApp.ViewModels;

namespace SELStudentApp.Presentation;

public sealed partial class DashboardPage : Page
{
    public DashboardPage()
    {
        this.InitializeComponent();
    }

    private void Page_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (DataContext is DashboardViewModel viewModel)
            viewModel.LoadCommand.Execute(null);
    }
}

