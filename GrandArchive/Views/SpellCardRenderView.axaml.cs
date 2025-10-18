using Avalonia;
using Avalonia.Controls;

namespace GrandArchive.Views;

public partial class SpellCardRenderView : UserControl
{
    public static readonly StyledProperty<bool> IsBleedingEdgeVisibleProperty = AvaloniaProperty.Register<SpellCardRenderView, bool>(
        nameof(IsBleedingEdgeVisible));

    public bool IsBleedingEdgeVisible
    {
        get => GetValue(IsBleedingEdgeVisibleProperty);
        set => SetValue(IsBleedingEdgeVisibleProperty, value);
    }
    public SpellCardRenderView()
    {
        InitializeComponent();
    }
}