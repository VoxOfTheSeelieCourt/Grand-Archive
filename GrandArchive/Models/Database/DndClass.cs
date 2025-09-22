using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

public partial class DndClass : DatabaseObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private bool _isPrestige;

    [ObservableProperty] private ICollection<DndClassSpell> _classSpells = new List<DndClassSpell>();
}