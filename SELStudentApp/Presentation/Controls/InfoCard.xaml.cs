namespace SELStudentApp.Presentation.Controls;

public sealed partial class InfoCard : UserControl
{
    public string? Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(nameof(Message), typeof(string), typeof(InfoCard), new PropertyMetadata(null));

    public InfoCard()
    {
        this.InitializeComponent();
    }
}
