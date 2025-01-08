namespace SELStudentApp.Presentation.Controls;

public sealed partial class PerformanceIndicator : UserControl
{
    public string? Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(nameof(Label), typeof(string), typeof(PerformanceIndicator), new PropertyMetadata(null));

    public string? Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(PerformanceIndicator), new PropertyMetadata(null));

    public PerformanceIndicator()
    {
        this.InitializeComponent();
    }
}
