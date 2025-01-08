using SELStudentApp.Core.Models.Curriculum;

namespace SELStudentApp.Presentation.Controls;
public sealed partial class PerfomancePartSection : UserControl
{
    public string? Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(PerfomancePartSection), new PropertyMetadata(null));

    public Part? Part
    {
        get { return (Part)GetValue(PartProperty); }
        set { SetValue(PartProperty, value); }
    }

    public static readonly DependencyProperty PartProperty =
        DependencyProperty.Register(nameof(Part), typeof(Part), typeof(PerfomancePartSection), new PropertyMetadata(null));

    public IEnumerable<Score> FilterScores(IEnumerable<Score> scores) => scores
        .Where(s => s.Value > 0)
        .OrderBy(s => s.Topic);

    public Visibility VisibleWhenNonZero(int value) => value > 0
        ? Visibility.Visible : Visibility.Collapsed;

    public PerfomancePartSection()
    {
        this.InitializeComponent();
    }
}
