// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SELStudentApp.Presentation.Controls;
public sealed partial class ScoreRow : UserControl
{
    public string? Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(ScoreRow), new PropertyMetadata(null));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(ScoreRow), new PropertyMetadata(null));

    public ScoreRow()
    {
        this.InitializeComponent();
    }
}
