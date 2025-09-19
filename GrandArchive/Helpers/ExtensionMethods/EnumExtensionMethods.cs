using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandArchive.Helpers.ExtensionMethods;

public static class EnumExtensionMethods
{
    public static IEnumerable<Enum> GetFlags(this Enum e)
    {
        return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
    }
}