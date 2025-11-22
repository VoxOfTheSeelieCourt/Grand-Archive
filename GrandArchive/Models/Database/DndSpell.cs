using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using GrandArchive.Helpers.Attributes;
#pragma warning disable CS0657 // Not a valid attribute location for this declaration

namespace GrandArchive.Models.Database;

[DebuggerDisplay("{Name}")]
public partial class DndSpell : DatabaseObject
{
    [ObservableProperty] [property:Required] private string _name;
    [ObservableProperty] private int? _rulebookPage;
    [ObservableProperty] private DndSpellSchool _school;
    [ObservableProperty] private DndSpellSubSchool _subSchool;
    [ObservableProperty] private DndSpellDescriptor _descriptor;

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

    [ObservableProperty] [property:Required] private string _castingTime;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(CustomRangeText))] [property:Required] private DndSpellRange _range;
    [ObservableProperty] [NotifyDataErrorInfo] [ConditionalRequired(nameof(Range), DndSpellRange.Custom)] private string _customRangeText;

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

    [ObservableProperty] [property:Required] private string _duration;
    [ObservableProperty] [property:Required] private string _savingThrow;
    [ObservableProperty] [property:Required] private string _spellResistance;
    [ObservableProperty] [property:Required] private string _descriptionShort;
    [ObservableProperty] private string _description;
    [ObservableProperty] private bool _isVerified;

    [ObservableProperty] [property:Required] private DndRulebook _rulebook;
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
    [NotMapped] public string ClassDisplayTextMultiLine => ClassSpells.Count + DomainSpells.Count != 0 ? string.Join("\n", GetClassesAndDomains()) : "";
    [NotMapped] public string ClassDisplayTextSingleLine => ClassSpells.Count + DomainSpells.Count != 0 ? string.Join(",", GetClassesAndDomains()) : "";
    [NotMapped] public bool DisplaySubschool => SubSchool != DndSpellSubSchool.None;
    [NotMapped] public bool DisplayDescriptor => Descriptor != DndSpellDescriptor.None;

    private List<string> GetClassesAndDomains()
    {
        var output = new List<string>();

        if (ClassSpells.Count != 0)
            output.AddRange(ClassSpells.Select(x => $"{x.Class.Name} {x.Level}"));
        if (DomainSpells.Count != 0)
            output.AddRange(DomainSpells.Select(x => $"{x.Domain.Name} {x.Level}"));

        return output;
    }

    #region Change Tracking

    [NotMapped] public bool HasChanges { get; set; }

    // ReSharper disable once CognitiveComplexity
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(HasChanges))
        {
            HasChanges = true;
        }

        // update validation rules
        switch (e.PropertyName)
        {
            case nameof(HasMaterialComponent):
                ValidateProperty(MaterialComponent, nameof(MaterialComponent));
                break;
            case nameof(HasArcaneFocus):
                ValidateProperty(ArcaneFocus, nameof(ArcaneFocus));
                break;
            case nameof(HasExperienceComponent):
                ValidateProperty(ExperienceComponent, nameof(ExperienceComponent));
                break;
            case nameof(HasTruenameComponent):
                ValidateProperty(TruenameComponent, nameof(TruenameComponent));
                break;
            case nameof(HasCorruptionComponent):
                ValidateProperty(CorruptionComponent, nameof(CorruptionComponent));
                break;
            case nameof(HasSacrificeComponent):
                ValidateProperty(SacrificeComponent, nameof(SacrificeComponent));
                break;
            case nameof(HasAbstinenceComponent):
                ValidateProperty(AbstinenceComponent, nameof(AbstinenceComponent));
                break;
            case nameof(HasMindsetComponent):
                ValidateProperty(MindsetComponent, nameof(MindsetComponent));
                break;
            case nameof(HasDrugComponent):
                ValidateProperty(DrugComponent, nameof(DrugComponent));
                break;
            case nameof(HasLocationComponent):
                ValidateProperty(LocationComponent, nameof(LocationComponent));
                break;
            case nameof(HasDragonmarkComponent):
                ValidateProperty(DragonmarkComponent, nameof(DragonmarkComponent));
                break;
            case nameof(HasDiseaseComponent):
                ValidateProperty(DiseaseComponent, nameof(DiseaseComponent));
                break;
            case nameof(HasColdfireComponent):
                ValidateProperty(ColdfireComponent, nameof(ColdfireComponent));
                break;
            case nameof(Range):
                ValidateProperty(CustomRangeText, nameof(CustomRangeText));
                break;
            case nameof(Target):
            case nameof(Effect):
            case nameof(Area):
                ValidateProperty(Target, nameof(Target));
                ValidateProperty(Effect, nameof(Effect));
                ValidateProperty(Area, nameof(Area));
                break;
        }

        base.OnPropertyChanged(e);
    }

    #endregion
}