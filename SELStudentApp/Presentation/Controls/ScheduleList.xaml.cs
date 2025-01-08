using SELStudentApp.ViewModels;

namespace SELStudentApp.Presentation.Controls;

public sealed partial class ScheduleList : UserControl
{
    public IEnumerable<ScheduleItemViewModel>? ScheduleItems
    {
        get => (IEnumerable<ScheduleItemViewModel>)GetValue(ScheduleItemsProperty);
        set => SetValue(ScheduleItemsProperty, value);
    }

    public static readonly DependencyProperty ScheduleItemsProperty =
        DependencyProperty.Register(nameof(ScheduleItems), typeof(IEnumerable<ScheduleItemViewModel>), typeof(ScheduleList), new PropertyMetadata(null));

    public ICommand LoadScheduleCommand
    {
        get => (ICommand)GetValue(LoadScheduleCommandProperty);
        set => SetValue(LoadScheduleCommandProperty, value);
    }

    public static readonly DependencyProperty LoadScheduleCommandProperty =
        DependencyProperty.Register(nameof(LoadScheduleCommand), typeof(ICommand), typeof(ScheduleList), new PropertyMetadata(null));

    public object? MessageContent
    {
        get => GetValue(MessageContentProperty);
        set => SetValue(MessageContentProperty, value);
    }

    public static readonly DependencyProperty MessageContentProperty =
        DependencyProperty.Register(nameof(MessageContent), typeof(object), typeof(ScheduleList), new PropertyMetadata(null));

    public event RoutedEventHandler? LoadScheduleButtonClick;

    public ScheduleList()
    {
        this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
        => LoadScheduleButtonClick?.Invoke(sender, e);
}
