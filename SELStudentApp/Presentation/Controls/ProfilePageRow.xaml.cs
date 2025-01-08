namespace SELStudentApp.Presentation.Controls;

public sealed partial class ProfilePageRow : UserControl
{
    public string? Title { get; set; }

    public string? Value
    {
        get => (string?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(ProfilePageRow), new PropertyMetadata(null));

    public ProfilePageRow()
    {
        this.InitializeComponent();
    }
}
