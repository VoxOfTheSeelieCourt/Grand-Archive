using System;

namespace GrandArchive.Models.Database;

[Flags]
public enum DndSpellSubSchool
{
    None = 0,
    Calling = 1 << 0,
    Charm = 1 << 1,
    Compulsion = 1 << 2,
    Creation = 1 << 3,
    Darkness = 1 << 4,
    Figment = 1 << 5,
    Glamer = 1 << 6,
    Healing = 1 << 7,
    Pattern = 1 << 8,
    Phantasm = 1 << 9,
    Polymorph = 1 << 10,
    Scrying = 1 << 11,
    Shadow = 1 << 12,
    Summoning = 1 << 13,
    Teleportation = 1 << 14
}