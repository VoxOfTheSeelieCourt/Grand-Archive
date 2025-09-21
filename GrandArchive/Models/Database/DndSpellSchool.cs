using System;

namespace GrandArchive.Models.Database;

[Flags]
public enum DndSpellSchool
{
    None = 0,
    Abjuration = 1 << 0,
    Conjuration = 1 << 1,
    Divination = 1 << 2,
    Enchantment = 1 << 3,
    Evocation = 1 << 4,
    Illusion = 1 << 5,
    Necromancy = 1 << 6,
    Transmutation = 1 << 7,
    Universal = 1 << 8
}