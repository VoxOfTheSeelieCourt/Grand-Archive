using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace GrandArchive.Models.Database;

public partial class DndClass : DatabaseObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private bool _isPrestige;

    [ObservableProperty] private ICollection<DndClassSpell> _classSpells;
}