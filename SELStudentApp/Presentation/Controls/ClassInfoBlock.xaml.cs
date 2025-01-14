namespace SELStudentApp.Presentation.Controls;

public sealed partial class ClassInfoBlock : UserControl
{
    public string? Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(ClassInfoBlock), new PropertyMetadata(null));

    public IconElement? Icon
    {
        get => (IconElement)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(ClassInfoBlock), new PropertyMetadata(null));

    public string? Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(ClassInfoBlock), new PropertyMetadata(null));

    public bool IsUrl(string url) => Uri.IsWellFormedUriString(url, UriKind.Absolute);

    public bool IsNotNull(object? value) => value is not null;

    public ClassInfoBlock()
    {
        this.InitializeComponent();
    }
}
