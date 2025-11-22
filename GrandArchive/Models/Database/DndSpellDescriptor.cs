using System;
using System.ComponentModel;

namespace GrandArchive.Models.Database;

[Flags]
public enum DndSpellDescriptor : long
{
    None = 0,
    Acid = 1L << 0,
    Air = 1L << 1,
    Chaotic = 1L << 2,
    Cold = 1L << 3,
    Darkness = 1L << 4,
    Death = 1L << 5,
    Earth = 1L << 6,
    Ectomancy = 1L << 7,
    Electricity = 1L << 8,
    Evil = 1L << 9,
    Fear = 1L << 10,
    Fire = 1L << 11,
    Force = 1L << 12,
    Good = 1L << 13,
    Incarnum = 1L << 14,
    [Description("Language-Dependant")]
    LanguageDependent = 1L << 15,
    Lawful = 1L << 16,
    Light = 1L << 17,
    [Description("Mind-Affecting")]
    MindAffecting = 1L << 18,
    Negative = 1L << 19,
    Positive = 1L << 20,
    Sonic = 1L << 21,
    Water = 1L << 22,
    Shadow = 1L << 23,
    Pattern = 1L << 24,
    Glamer = 1L << 25,
    Investiture = 1L << 26,
    Teleportation = 1L << 27,
    Creation = 1L << 28,
    Ice = 1L << 29,
    Compulsion = 1L << 30,
    Summoning = 1L << 31,
    Mindset = 1L << 32,
    Various = 1L << 63,
}