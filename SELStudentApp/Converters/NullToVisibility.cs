using Microsoft.UI.Xaml.Data;

namespace SELStudentApp.Converters;

public class NullToVisibility : IValueConverter
{
    public Visibility WhenNull { get; set; }

    public Visibility WhenNonNull { get; set; }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is null ? WhenNull : WhenNonNull;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
