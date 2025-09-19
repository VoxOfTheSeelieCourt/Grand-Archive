using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GrandArchive.Helpers;

public class NullToBoolConverter : IValueConverter
{
    public bool NullOutput { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? NullOutput : !NullOutput;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}