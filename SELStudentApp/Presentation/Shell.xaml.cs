using SELStudentApp.ViewModels;

namespace SELStudentApp.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider
{
    public Shell()
    {
        this.InitializeComponent();
    }

    private async void Shell_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (DataContext is ShellViewModel viewModel)
            await viewModel.Navigate();
    }

    public ContentControl ContentControl => Splash;
}
