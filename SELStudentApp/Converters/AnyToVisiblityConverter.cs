using System.Collections;
using Microsoft.UI.Xaml.Data;
using Uno.Extensions.Specialized;

namespace SELStudentApp.Converters;
public class AnyToVisiblityConverter : IValueConverter
{
    public Visibility WhenEmpty { get; set; }

    public Visibility WhenAny { get; set; }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is IEnumerable items && items.Any() ? WhenAny : WhenEmpty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
