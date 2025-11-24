using System;
using System.Diagnostics;
using Avalonia.Media;

namespace GrandArchive.Models;

[DebuggerDisplay("{Name} ({Type})")]
public class NavigationBarEntry
{
    public Type Type { get; init; }
    public string Name { get; init; }

    public StreamGeometry Icon { get; init; }
}