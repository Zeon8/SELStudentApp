using Microsoft.UI.Xaml.Data;

namespace SELStudentApp.Converters;

public class StringNullOrEmptyToVisiblity : IValueConverter
{
    public Visibility WhenTrue { get; set; }

    public Visibility WhenFalse { get; set; }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return string.IsNullOrEmpty(value as string) ? WhenTrue : WhenFalse;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
