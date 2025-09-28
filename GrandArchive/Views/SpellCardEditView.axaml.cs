using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using GrandArchive.Models.Database;

namespace GrandArchive.Views;

public partial class SpellCardEditView : UserControl
{
    public static readonly StyledProperty<List<DndClass>> DndClassesProperty = AvaloniaProperty.Register<SpellCardEditView, List<DndClass>>(
        nameof(DndClasses));

    public static readonly StyledProperty<List<DndRulebook>> DndRuleBooksProperty = AvaloniaProperty.Register<SpellCardEditView, List<DndRulebook>>(
        nameof(DndRuleBooks));

    public List<DndClass> DndClasses
    {
        get => GetValue(DndClassesProperty);
        set => SetValue(DndClassesProperty, value);
    }

    public List<DndRulebook> DndRuleBooks
    {
        get => GetValue(DndRuleBooksProperty);
        set => SetValue(DndRuleBooksProperty, value);
    }

    public SpellCardEditView()
    {
        InitializeComponent();
    }
}