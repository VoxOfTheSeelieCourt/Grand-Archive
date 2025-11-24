using System.Collections.Generic;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

[DebuggerDisplay("{Id} - {Name} ({System})")]
public partial class DndEdition : DatabaseObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _system;

    [ObservableProperty]  private ICollection<DndRulebook> _rulebooks = new List<DndRulebook>();
}