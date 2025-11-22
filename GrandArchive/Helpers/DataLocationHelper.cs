using System;
using System.IO;

namespace GrandArchive.Helpers;

public static class DataLocationHelper
{
    public static string GetRootFolder()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GrandArchive");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }
}