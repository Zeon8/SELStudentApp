using SELStudentApp.ViewModels;

namespace SELStudentApp.Presentation;

public sealed partial class CurriculumPage : Page
{
    public CurriculumPage()
    {
        this.InitializeComponent();
    }

    private void Page_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (DataContext is CurriculumViewModel viewModel)
            viewModel.LoadCommand.Execute(null);
    }
}
