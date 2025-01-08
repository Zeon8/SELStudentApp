namespace SELStudentApp.Presentation.Controls;

public sealed partial class CopyRow : UserControl
{
    public string? Title { get; set; }

    public string? CopyText
    {
        get => (string)GetValue(CopyTextProperty);
        set => SetValue(CopyTextProperty, value);
    }

    public static readonly DependencyProperty CopyTextProperty =
        DependencyProperty.Register(nameof(CopyText), typeof(string), typeof(CopyRow), new PropertyMetadata(null));

    public ICommand? CopyCommand
    {
        get => (ICommand)GetValue(CopyCommandProperty);
        set => SetValue(CopyCommandProperty, value);
    }

    public static readonly DependencyProperty CopyCommandProperty =
        DependencyProperty.Register(nameof(CopyCommand), typeof(ICommand), typeof(CopyRow), new PropertyMetadata(null));

    public CopyRow()
    {
        this.InitializeComponent();
    }
}
