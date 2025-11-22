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
        if (value == null)
            return null;

        var enumType = Nullable.GetUnderlyingType(value.GetType()) ?? value.GetType();

        if (enumType.IsEnum == false)
            throw new ArgumentException("Type must be an Enum.");

        return new EnumerationMember
        {
            Value = value,
            Description = EnumerationExtension.GetDescription(value, enumType)
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is EnumerationMember enumerationMember ? enumerationMember.Value : null;
    }
}