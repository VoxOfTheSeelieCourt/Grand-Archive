using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GrandArchive.Helpers.Converter;

public class PercentageConverter : IMultiValueConverter
{
    public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is not [int verified, int all])
            return 0;

        return verified * 100 / (double)all;
    }
}