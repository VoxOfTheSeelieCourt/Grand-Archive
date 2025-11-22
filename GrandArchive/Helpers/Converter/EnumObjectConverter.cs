using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GrandArchive.Helpers.Converter;

public class EnumObjectConverter : IValueConverter
{
    public Dictionary<string, object> ObjectMap { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null ? ObjectMap.GetValueOrDefault(value.ToString()) : null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}