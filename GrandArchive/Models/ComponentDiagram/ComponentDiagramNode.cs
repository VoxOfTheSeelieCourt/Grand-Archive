using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.ComponentDiagram;

[DebuggerDisplay("{RawName}")]
public partial class ComponentDiagramNode : ObservableObject
{
    [ObservableProperty] private string _rawName;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(ComponentTypeEnum))] private string _rawType;
    [ObservableProperty] private string _rawComponents;
    [ObservableProperty] private string _rawComponentCosts;
    [ObservableProperty] private string _rawTotalCost;
    [ObservableProperty] private string _rawResult;
    [ObservableProperty] private string _rawTimePerUnit;
    [ObservableProperty] private string _rawFacilities;
    [ObservableProperty] private string _rawDifficulty;
    [ObservableProperty] private string _rawDescription;

    public ComponentType? ComponentTypeEnum => RawType switch
    {
        "Undefined" => ComponentType.Undefined,
        "Component" => ComponentType.Component,
        "Construction" => ComponentType.Construction,
        "Consumable" => ComponentType.Consumable,
        "Essential Component" => ComponentType.Essential,
        "Module" => ComponentType.Module,
        "Power Component" => ComponentType.Power,
        "Basic Resource" => ComponentType.Basic,
        // "Raw Resource" => ComponentType.Basic,
        "Structural Component" => ComponentType.Structural,
        _ => ComponentType.Raw,
    };

    public ComponentDiagramNode() { }

    public ComponentDiagramNode(string rawName, string rawType) : this()
    {
        _rawName = rawName;
        _rawType = rawType;
    }

    public ComponentDiagramNode(string rawName, string rawType, string rawComponents, string rawComponentCosts, string rawTotalCost, string rawResult, string rawTimePerUnit, string rawFacilities, string rawDifficulty, string rawDescription)
    {
        _rawName = rawName;
        _rawType = rawType;
        _rawComponents = rawComponents;
        _rawComponentCosts = rawComponentCosts;
        _rawTotalCost = rawTotalCost;
        _rawResult = rawResult;
        _rawTimePerUnit = rawTimePerUnit;
        _rawFacilities = rawFacilities;
        _rawDifficulty = rawDifficulty;
        _rawDescription = rawDescription;
    }
}

public enum ComponentType
{
    Undefined,
    Component,
    Construction,
    Consumable,
    Essential,
    Module,
    Power,
    Basic,
    Raw,
    Structural
}