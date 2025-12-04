using System;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using GrandArchive.Helpers.ExtensionMethods;

namespace GrandArchive.Helpers.Converter;

public class EnumDescriptorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return null;

        if (value is not Enum e)
            throw new ArgumentException($"{nameof(value)} must be of type {typeof(Enum).FullName}");

        if (!e.IsFlagEnum())
            return e.GetDescription();

        var selectedLong = System.Convert.ToInt64(e);
        var values = Enum.GetValues(e.GetType());

        var selected = (from Enum v in values
            let numericValue = System.Convert.ToInt64(v)
            where numericValue != 0 && (numericValue == 1 || numericValue % 2 == 0) && (selectedLong & numericValue) == numericValue
            select v.GetDescription()).ToList();

        return string.Join(", ", selected);

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}