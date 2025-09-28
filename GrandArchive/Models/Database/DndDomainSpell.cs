using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace GrandArchive.Models.Database;

[Index(nameof(DomainId), nameof(SpellId), IsUnique = true)]
[DebuggerDisplay("{Spell.Name ?? SpellId.ToString()}: {Domain.Name ?? DomainId.ToString()} {Level}")]
public partial class DndDomainSpell : DatabaseObject
{
    [ObservableProperty] private int _level;

    // name those two explicitly so an index can be applied
    [ObservableProperty] private int _domainId;
    [ObservableProperty] private int _spellId;

    [ObservableProperty] private DndDomain _domain;
    [ObservableProperty] private DndSpell _spell;
}