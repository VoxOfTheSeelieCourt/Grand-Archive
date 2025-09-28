using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

public partial class DndSpell : DatabaseObject
{
    [ObservableProperty] private string _name;
    [ObservableProperty] private int? _rulebookPage;
    [ObservableProperty] private DndSpellSchool _school;
    [ObservableProperty] private DndSpellSubSchool _subSchool;
    [ObservableProperty] private DndSpellDescriptor _descriptor;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasVerbalComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasSomaticComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasMaterialComponent;
    [ObservableProperty] private string _materialComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasArcaneFocus;
    [ObservableProperty] private string _arcaneFocus;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDivineFocus;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasExperienceComponent;
    [ObservableProperty] private string _experienceComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasBreathComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasTruenameComponent;
    [ObservableProperty] private string _truenameComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasCorruptionComponent;
    [ObservableProperty] private string _corruptionComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasSacrificeComponent;
    [ObservableProperty] private string _sacrificeComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasAbstinenceComponent;
    [ObservableProperty] private string _abstinenceComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasMindsetComponent;
    [ObservableProperty] private string _mindsetComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDrugComponent;
    [ObservableProperty] private string _drugComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasLocationComponent;
    [ObservableProperty] private string _locationComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDragonmarkComponent;
    [ObservableProperty] private string _dragonmarkComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDiseaseComponent;
    [ObservableProperty] private string _diseaseComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasColdfireComponent;
    [ObservableProperty] private string _coldfireComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private string _extraComponent;
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
    [ObservableProperty] private ICollection<DndClassSpell> _classSpells =  new List<DndClassSpell>();

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
            if (HasCorruptionComponent) components.Add("Cor");
            if (HasSacrificeComponent) components.Add("Sac");
            if (HasAbstinenceComponent) components.Add("AB");
            if (HasMindsetComponent) components.Add("Mind");
            if (HasDrugComponent) components.Add("Drug");
            if (HasLocationComponent) components.Add("Loc");
            if (HasDragonmarkComponent) components.Add("DM");
            if (HasDiseaseComponent) components.Add("DS");
            if (HasColdfireComponent) components.Add("CF");
            if (!string.IsNullOrEmpty(ExtraComponent)) components.Add("E");

            return string.Join(",", components);
        }
    }

    [NotMapped] public string RangeDisplayText => Range == DndSpellRange.Custom ? CustomRangeText : Range.ToString();
    [NotMapped] public string ClassDisplayTextMultiLine => ClassSpells.Any() ? string.Join("\n", ClassSpells.Select(x => $"{x.Class.Name} {x.Level}")) : "";
    [NotMapped] public string ClassDisplayTextSingleLine => ClassSpells.Any() ? string.Join(",", ClassSpells.Select(x => $"{x.Class.Name} {x.Level}")) : "";
    [NotMapped] public bool DisplaySubschool => SubSchool != DndSpellSubSchool.None;
    [NotMapped] public bool DisplayDescriptor => Descriptor != DndSpellDescriptor.None;
    [NotMapped] public bool HasChanges { get; set; }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(HasChanges))
        {
            HasChanges = true;
        }

        base.OnPropertyChanged(e);
    }
}