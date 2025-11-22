using System.IO;
using System.Linq;

namespace GrandArchive.Helpers.ExtensionMethods;

public static class StringExtensionMethods
{
    public static string SanitizeFileName(this string path)
    {
        var lastBackslash = path.LastIndexOf('\\');

        var dir = lastBackslash >= 0 ? path[..lastBackslash] : "";
        var file = lastBackslash >= 0 ? path[lastBackslash..] : path;

        file = Path.GetInvalidFileNameChars().Aggregate(file, (current, invalid) => current.Replace(invalid, '_'));

        return dir + file;
    }
}