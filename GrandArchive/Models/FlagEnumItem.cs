using System;

namespace GrandArchive.Models;

public class FlagEnumItem
{
    public Enum Value { get; set; }
    public string DisplayName { get; set; }
    public bool IsChecked { get; set; }
}