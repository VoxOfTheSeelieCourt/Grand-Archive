using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GrandArchive.Helpers.ExtensionMethods;

public static class EnumExtensionMethods
{
    public static IEnumerable<Enum> GetFlags(this Enum e)
    {
        return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
    }

    public static string GetDescription(this Enum enumValue)
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());

        if (field == null)
            return "No description";

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? enumValue.ToString();
    }

    public static bool IsFlagEnum(this Enum e)
    {
        return e.GetType().IsFlagEnum();
    }

    public static bool IsFlagEnum(this Type enumType)
    {
        if (enumType is not { IsEnum: true })
            return false;
        return enumType.GetCustomAttribute<FlagsAttribute>() != null;
    }
}