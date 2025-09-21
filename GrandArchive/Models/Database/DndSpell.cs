using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

public partial class DndSpell : DatabaseObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private int? _rulebookPage;
    [ObservableProperty] private DndSpellSchool _school;
    [ObservableProperty] private DndSpellSubSchool _subSchool;
    [ObservableProperty] private DndSpellDescriptor _descriptor;
    [ObservableProperty] private bool _hasVerbalComponent;
    [ObservableProperty] private bool _hasSomaticComponent;
    [ObservableProperty] private bool _hasMaterialComponent;
    [ObservableProperty] private string _materialComponent;
    [ObservableProperty] private bool _hasArcaneFocus;
    [ObservableProperty] private bool _hasDivineFocus;
    [ObservableProperty] private bool _hasExperienceComponent;
    [ObservableProperty] private string _experienceComponent;
    [ObservableProperty] private bool _hasBreathComponent;
    [ObservableProperty] private bool _hasTruenameComponent;
    [ObservableProperty] private bool _hasCorruptionComponent;
    [ObservableProperty] private string _corruptionComponent;
    [ObservableProperty] private string _extraComponent;
    [ObservableProperty] private string _castingTime;
    [ObservableProperty] private DndSpellRange _range;
    [ObservableProperty] private string _customRangeText;
    [ObservableProperty] private string _target;
    [ObservableProperty] private string _effect;
    [ObservableProperty] private string _area;
    [ObservableProperty] private string _duration;
    [ObservableProperty] private string _savingThrow;
    [ObservableProperty] private string _spellResistance;
    [ObservableProperty] private string _descriptionShort;
    [ObservableProperty] private string _description;
    [ObservableProperty] private bool _isVerified;
    
    [ObservableProperty] private DndRulebook _rulebook;

    [NotMapped]
    public string AllComponents
    {
        get
        {
            var components = new List<string>();
            
            if (HasVerbalComponent) components.Add("V");
            if (HasSomaticComponent) components.Add("S");
            if (HasMaterialComponent) components.Add("M");
            if (HasArcaneFocus) components.Add("AF");
            if (HasDivineFocus) components.Add("DF");
            if (HasExperienceComponent) components.Add("XP");
            if (HasBreathComponent) components.Add("BR");
            if (HasTruenameComponent) components.Add("TN");
            if (HasCorruptionComponent) components.Add("CR");
            
            return string.Join(",", components);
        }
    }

    [NotMapped] public string RangeDisplayText => Range == DndSpellRange.Custom ? CustomRangeText : Range.ToString();
    [NotMapped] public bool DisplaySubschool => SubSchool != DndSpellSubSchool.None;
    [NotMapped] public bool DisplayDescriptor => Descriptor != DndSpellDescriptor.None;
    [NotMapped] public bool HasChanges { get; private set; }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(HasChanges))
        {
            HasChanges = true;
        }

        base.OnPropertyChanged(e);
    }
}