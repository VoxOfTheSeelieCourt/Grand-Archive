using System.Collections.Generic;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

[DebuggerDisplay("{Id} - {Name}")]
public partial class DndRulebook : DatabaseObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _abbreviation;
    [ObservableProperty] private string _description;
    [ObservableProperty] private int? _publishingDay;
    [ObservableProperty] private int? _publishingMonth;
    [ObservableProperty] private int? _publishingYear;

    [ObservableProperty] private DndEdition _dndEdition;
    [ObservableProperty] private ICollection<DndSpell> _spells = new List<DndSpell>();

    public override bool Equals(object obj)
    {
        return obj is DndRulebook rulebook && rulebook.Id == Id;
    }
}