using System.Collections.Generic;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

[DebuggerDisplay("{Name}")]
public partial class DndDomain : DatabaseObject
{
    [ObservableProperty] private string _name;

    [ObservableProperty] private ICollection<DndDomainSpell> _domainSpells = new List<DndDomainSpell>();
}