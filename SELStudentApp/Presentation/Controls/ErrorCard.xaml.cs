namespace SELStudentApp.Presentation.Controls;

public sealed partial class ErrorCard : UserControl
{
    public string? Message
    {
        get => (string?)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(nameof(Message), typeof(string), typeof(ErrorCard), new PropertyMetadata(null));

    public ErrorCard()
    {
        this.InitializeComponent();
    }
}
