using System;

namespace GrandArchive.Models.Database;

[Flags]
public enum DndSpellRange
{
    Personal = 1 << 0,
    Touch = 1 << 1,
    Close = 1 << 2,
    Medium = 1 << 3,
    Long = 1 << 4,
    Unlimited = 1 << 5,
    Custom = 1 << 6,
}