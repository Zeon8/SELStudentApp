namespace SELStudentApp.Presentation.Controls;

public sealed partial class DashboardButton : UserControl
{
    public string? Header { get; set; }

    public string? SubHeader { get; set; }

    public object? Icon { get; set; }

    public string? Route
    {
        get => (string?)GetValue(RouteProperty);
        set => SetValue(RouteProperty, value);
    }

    public static readonly DependencyProperty RouteProperty =
        DependencyProperty.Register(nameof(Route), typeof(string), typeof(DashboardButton), new PropertyMetadata(null));

    public DashboardButton()
    {
        this.InitializeComponent();
    }
}
