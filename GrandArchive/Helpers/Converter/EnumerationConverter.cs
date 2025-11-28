using System;
using System.Globalization;
using Avalonia.Data.Converters;
using GrandArchive.Helpers.MarkupExtensions;
using GrandArchive.Models;

namespace GrandArchive.Helpers.Converter;

public class EnumerationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || value is not Enum e)
            return null;

        var enumType = Nullable.GetUnderlyingType(e.GetType()) ?? e.GetType();

        if (enumType.IsEnum == false)
            throw new ArgumentException("Type must be an Enum.");

        return new EnumItem
        {
            Value = e,
            DisplayName = EnumerationExtension.GetDescription(e, enumType)
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is EnumItem enumerationMember ? enumerationMember.Value : null;
    }
}