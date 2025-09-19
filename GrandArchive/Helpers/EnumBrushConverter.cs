using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace GrandArchive.Helpers;

public class EnumBrushConverter : IValueConverter
{
    public Dictionary<string, Brush> Brushes { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null ? Brushes.GetValueOrDefault(value.ToString()) : null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}