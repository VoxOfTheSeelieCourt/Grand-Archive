using System;
using System.ComponentModel;
using System.Linq;
using Avalonia.Markup.Xaml;
using GrandArchive.Models;

namespace GrandArchive.Helpers.MarkupExtensions;

public class EnumerationExtension : MarkupExtension
{
    private readonly Type _enumType = null!;

    public EnumerationExtension(Type enumType)
    {
        EnumType = enumType ?? throw new ArgumentException("Enum type must not be null", nameof(enumType));
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public Type EnumType
    {
        get => _enumType;
        private init
        {
            if (_enumType == value)
                return;

            var enumType = Nullable.GetUnderlyingType(value) ?? value;

            if (enumType.IsEnum == false)
                throw new ArgumentException("Type must be an Enum.");

            _enumType = value;
        }
    }

    public override Array ProvideValue(IServiceProvider serviceProvider)
    {
        var enumValues = Enum.GetValues(EnumType);

        return (from Enum enumValue in enumValues
            select new EnumItem
            {
                Value = enumValue,
                DisplayName = GetDescription(enumValue, EnumType)
            }).ToArray();
    }

    public static string GetDescription(object enumValue, Type enumType)
    {
        if (enumValue == null)
            throw new ArgumentException("Enum value must not be null", nameof(enumValue));

        var str = enumValue.ToString();

        if (str == null)
            throw new ArgumentException("Enum value must not be null when converted to string", nameof(enumValue));

        var descriptionAttribute = enumType.GetField(str)?
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;

        return descriptionAttribute?.Description ?? str;
    }
}