using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandArchive.Helpers.Attributes;
#pragma warning disable CS0657 // Not a valid attribute location for this declaration

namespace GrandArchive.Models.Database;

[DebuggerDisplay("{Name}")]
public partial class DndSpell : DatabaseObject
{
    [ObservableProperty] [Required] private string _name;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DisplaySourceLong))] [RequireOneOfList("Page", nameof(RulebookPage))] [NotifyDataErrorInfo] private int? _rulebookPage;
    [ObservableProperty] private DndSpellSchool _school;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DisplaySubschool))] private DndSpellSubSchool _subSchool;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DisplayDescriptor))] private DndSpellDescriptor _descriptor;

    #region Components

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasVerbalComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasSomaticComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MaterialComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasMaterialComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(ArcaneFocus))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasArcaneFocus;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDivineFocus;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(ExperienceComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasExperienceComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasBreathComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(TruenameComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasTruenameComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(CorruptionComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasCorruptionComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(SacrificeComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasSacrificeComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AbstinenceComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasAbstinenceComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MindsetComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasMindsetComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DrugComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDrugComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(LocationComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasLocationComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DragonmarkComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDragonmarkComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DiseaseComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasDiseaseComponent;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(ColdfireComponent))] [NotifyPropertyChangedFor(nameof(AllComponents))] private bool _hasColdfireComponent;

    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasMaterialComponent), true)] private string _materialComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasArcaneFocus), true)] private string _arcaneFocus;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasExperienceComponent), true)] private string _experienceComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasTruenameComponent), true)] private string _truenameComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasCorruptionComponent), true)] private string _corruptionComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasSacrificeComponent), true)] private string _sacrificeComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasAbstinenceComponent), true)] private string _abstinenceComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasMindsetComponent), true)] private string _mindsetComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasDrugComponent), true)] private string _drugComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasLocationComponent), true)] private string _locationComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasDragonmarkComponent), true)] private string _dragonmarkComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasDiseaseComponent), true)] private string _diseaseComponent;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(HasColdfireComponent), true)] private string _coldfireComponent;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(AllComponents))] private string _extraComponent;

    #endregion

    [ObservableProperty] [Required] private string _castingTime;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(RangeDisplayText), nameof(CustomRangeText))] [NotifyDataErrorInfo] [Required] private DndSpellRange _range;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(RangeDisplayText), nameof(Range))] [NotifyDataErrorInfo] [ConditionalRequired(nameof(Range), DndSpellRange.Custom)] private string _customRangeText;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RequireOneOfList("Spell Effect", nameof(Target), nameof(Effect), nameof(Area))]
    [NotifyPropertyChangedFor(nameof(Effect), nameof(Area))]
    private string _target;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RequireOneOfList("Spell Effect", nameof(Target), nameof(Effect), nameof(Area))]
    [NotifyPropertyChangedFor(nameof(Target), nameof(Area))]
    private string _effect;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RequireOneOfList("Spell Effect", nameof(Target), nameof(Effect), nameof(Area))]
    [NotifyPropertyChangedFor(nameof(Target), nameof(Effect))]
    private string _area;

    [ObservableProperty] [Required] private string _duration;
    [ObservableProperty] [Required] private string _savingThrow;
    [ObservableProperty] [Required] private string _spellResistance;
    [ObservableProperty] [Required] private string _descriptionShort;
    [ObservableProperty] [Required] private string _description;
    [ObservableProperty] private string _flavorText;
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(ToggleVerifiedCommand))] private bool _isVerified;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DisplaySourceLong))] [Required] private DndRulebook _rulebook;
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    [ObservableProperty] private DndSpell? _variantOfSpell;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    [ObservableProperty] private ICollection<DndSpell> _spellVariants;
    [ObservableProperty] private ICollection<DndClassSpell> _classSpells =  new List<DndClassSpell>();
    [ObservableProperty] private ICollection<DndDomainSpell> _domainSpells =  new List<DndDomainSpell>();

    [NotMapped]
    public string AllComponents
    {
        // ReSharper disable once CognitiveComplexity
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
            if (HasTruenameComponent) components.Add("T");
            if (HasCorruptionComponent) components.Add("Cor");
            if (HasSacrificeComponent) components.Add("Sac");
            if (HasAbstinenceComponent) components.Add("Ab");
            if (HasMindsetComponent) components.Add("Mind");
            if (HasDrugComponent) components.Add("Drug");
            if (HasLocationComponent) components.Add("Loc");
            if (HasDragonmarkComponent) components.Add("DM");
            if (HasDiseaseComponent) components.Add("Dis");
            if (HasColdfireComponent) components.Add("CF");
            if (!string.IsNullOrEmpty(ExtraComponent)) components.Add("E");

            return string.Join(",", components);
        }
    }

    [NotMapped] public string RangeDisplayText => Range == DndSpellRange.Custom ? CustomRangeText : Range.ToString();
    [NotMapped] public string ClassDisplayTextMultiLine => ClassSpells.Count + DomainSpells.Count != 0 ? string.Join("\n", GetClassesAndDomains()) : "";
    [NotMapped] public string ClassDisplayTextSingleLine => ClassSpells.Count + DomainSpells.Count != 0 ? string.Join(",", GetClassesAndDomains()) : "";
    [NotMapped] public bool DisplaySubschool => SubSchool != DndSpellSubSchool.None;
    [NotMapped] public bool DisplayDescriptor => Descriptor != DndSpellDescriptor.None;
    [NotMapped] public string DisplaySourceLong => $"{Rulebook?.Name} [{Rulebook?.DndEdition.System.Replace("DnD ", "")}]{(RulebookPage.HasValue ? $" p. {RulebookPage}" : "")}";

    private List<string> GetClassesAndDomains()
    {
        var output = new List<string>();

        if (ClassSpells.Count != 0)
            output.AddRange(ClassSpells.Select(x => $"{x.Class.Name} {x.Level}"));
        if (DomainSpells.Count != 0)
            output.AddRange(DomainSpells.Select(x => $"{x.Domain.Name} {x.Level}"));

        return output;
    }

    [RelayCommand(CanExecute = nameof(CanToggleVerified))]
    private void ToggleVerified()
    {
        IsVerified = !IsVerified;
    }

    private bool CanToggleVerified()
    {
        return IsVerified || !HasErrors;
    }

    public DndSpell()
    {
        ErrorsChanged += (_, _) => ToggleVerifiedCommand.NotifyCanExecuteChanged();
        ValidateAllProperties();
    }

    #region Change Tracking

    [NotMapped] public bool HasChanges { get; set; }

    private readonly string[] _ignoreChangeTrackingProperties =
    [
        nameof(HasErrors),
        nameof(HasChanges),
        nameof(UpdatedAt),
        nameof(RangeDisplayText),
        nameof(ClassDisplayTextMultiLine),
        nameof(ClassDisplayTextSingleLine),
        nameof(DisplaySubschool),
        nameof(DisplayDescriptor),
        nameof(DisplaySourceLong),
    ];

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (!_ignoreChangeTrackingProperties.Contains(e.PropertyName))
        {
            HasChanges = true;
            ValidateAllProperties();
        }

        base.OnPropertyChanged(e);
    }

    #endregion
}