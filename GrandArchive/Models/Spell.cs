using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models;

public partial class Spell : ObservableObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _source;
    [ObservableProperty] private SpellSchool _spellSchools;
    [ObservableProperty] private SpellSubSchool _spellSubSchools;
    [ObservableProperty] private SpellDescriptor _spellDescriptors;
    [ObservableProperty] private Dictionary<string, int> _levelPerClass;
    [ObservableProperty] private Dictionary<SpellComponent, string> _spellComponents;
    [ObservableProperty] private string _castingTime;
    [ObservableProperty] private string _range;
    [ObservableProperty] private string _target;
    [ObservableProperty] private string _area;
    [ObservableProperty] private string _effect;
    [ObservableProperty] private bool _needsConcentration;
    [ObservableProperty] private string _duration;
    [ObservableProperty] private bool _savingThrow;
    [ObservableProperty] private string _saves;
    [ObservableProperty] private bool _allowsSpellResistance;
    [ObservableProperty] private bool _isHarmless;
    [ObservableProperty] private bool _targetsObject;
    [ObservableProperty] private string _description;
}