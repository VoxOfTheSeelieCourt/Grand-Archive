using System;

namespace GrandArchive.Models;

public struct EnumItem
{
    public Enum Value { get; set; }
    public string DisplayName { get; set; }

    public override string ToString()
    {
        return DisplayName;
    }
}