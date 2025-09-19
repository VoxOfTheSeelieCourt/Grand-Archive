using System;
using Avalonia.Media;

namespace GrandArchive.Models;

public class NavigationBarEntry
{
    public Type Type { get; init; }
    public string Name { get; init; }

    public StreamGeometry Icon { get; init; }
}