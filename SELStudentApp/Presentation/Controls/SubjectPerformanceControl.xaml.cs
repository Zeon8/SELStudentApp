using Microsoft.UI.Xaml.Controls.Primitives;

namespace SELStudentApp.Presentation.Controls;
public sealed partial class SubjectPerformanceControl : UserControl
{
    public Flyout? Flyout { get; set; }

    public SubjectPerformanceControl()
    {
        this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Flyout?.Hide();
    }
}
