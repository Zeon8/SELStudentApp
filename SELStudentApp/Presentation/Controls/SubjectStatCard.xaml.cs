namespace SELStudentApp.Presentation.Controls;

public sealed partial class SubjectStatCard : UserControl
{
    public string? Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(SubjectStatCard), new PropertyMetadata(null));

    public string? Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(SubjectStatCard), new PropertyMetadata(null));

    public string? Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public static readonly DependencyProperty SubtitleProperty =
        DependencyProperty.Register(nameof(Subtitle), typeof(string), typeof(SubjectStatCard), new PropertyMetadata(null));

    public SubjectStatCard()
    {
        this.InitializeComponent();
    }
}
