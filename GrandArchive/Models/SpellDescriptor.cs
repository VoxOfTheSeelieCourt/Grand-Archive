using System;

namespace GrandArchive.Models;

[Flags]
public enum SpellDescriptor
{
    None = 0,
    Acid = 1 << 0,
    Air = 1 << 1,
    Chaotic = 1 << 2,
    Cold = 1 << 3,
    Darkness = 1 << 4,
    Death = 1 << 5,
    Earth = 1 << 6,
    Ectomancy = 1 << 7,
    Electricity = 1 << 8,
    Evil = 1 << 9,
    Fear = 1 << 10,
    Fire = 1 << 11,
    Force = 1 << 12,
    Good = 1 << 13,
    Incarnum = 1 << 14,
    LanguageDependent = 1 << 15,
    Lawful = 1 << 16,
    Light = 1 << 17,
    MindAffecting = 1 << 18,
    Negative = 1 << 19,
    Positive = 1 << 20,
    Sonic = 1 << 21,
    Water = 1 << 22
}