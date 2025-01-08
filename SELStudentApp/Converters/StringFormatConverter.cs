using Microsoft.UI.Xaml.Data;

namespace SELStudentApp.Converters;

public class StringFormatConverter : IValueConverter
{
    public required string Formatting { get; set; }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return string.Format(Formatting, value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
