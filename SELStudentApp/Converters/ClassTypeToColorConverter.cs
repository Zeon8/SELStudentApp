using Microsoft.UI.Xaml.Data;
using SELStudentApp.Core.Models;
using Windows.UI;

namespace SELStudentApp.Converters;
public class ClassTypeToColorConverter : IValueConverter
{
    public Color DefaultColor { get; set; }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return new SolidColorBrush(value switch
        {
            ClassType.Lecture => Color.FromArgb(255, 255, 218, 185),
            ClassType.Practice => Color.FromArgb(255, 176, 224, 230),
            ClassType.Lab => Color.FromArgb(255, 221, 160, 221),
            ClassType.Consultation => Color.FromArgb(255, 144, 238, 144),
            ClassType.SemesterExams => Color.FromArgb(255, 255, 182, 193),
            _ => DefaultColor
        });
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
