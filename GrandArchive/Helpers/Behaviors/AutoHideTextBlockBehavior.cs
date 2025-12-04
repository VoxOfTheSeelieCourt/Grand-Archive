using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;
using AvaloniaEdit.Utils;

namespace GrandArchive.Helpers.Behaviors;

public class AutoHideTextBlockBehavior : Behavior<TextBlock>
{
    private IDisposable _boundsSubscription;
    private IDisposable _textSubscription;
    private IDisposable _hideWhenTextEmptyOrNull;

    public static readonly StyledProperty<bool> HideWhenTextEmptyOrNullProperty = AvaloniaProperty.Register<AutoHideTextBlockBehavior, bool>(
        nameof(HideWhenTextNullOrEmpty));

    public bool HideWhenTextNullOrEmpty
    {
        get => GetValue(HideWhenTextEmptyOrNullProperty);
        set => SetValue(HideWhenTextEmptyOrNullProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        if (AssociatedObject == null)
            return;

        // Subscribe to bounds changes
        _boundsSubscription = AssociatedObject.GetObservable(Visual.BoundsProperty)
            .Subscribe(_ =>
            {
                Debug.WriteLine("Bounds changed");
                UpdateVisibility();
            });

        // Subscribe to text changes
        _textSubscription = AssociatedObject.GetObservable(TextBlock.TextProperty)
            .Subscribe(_ =>
            {
                Debug.WriteLine("Text changed");
                UpdateVisibility();
            });

        _hideWhenTextEmptyOrNull = this.GetObservable(HideWhenTextEmptyOrNullProperty)
            .Subscribe(_ =>
            {
                Debug.WriteLine("HideEmpty changed");
                UpdateVisibility();
            });

        // Initial check
        UpdateVisibility();
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        _boundsSubscription?.Dispose();
        _boundsSubscription = null;

        _textSubscription?.Dispose();
        _textSubscription = null;

        _hideWhenTextEmptyOrNull?.Dispose();
        _hideWhenTextEmptyOrNull = null;
    }

    private void UpdateVisibility()
    {
        if (AssociatedObject == null)
        {
            return;
        }

        var text = AssociatedObject.Text;
        if (string.IsNullOrEmpty(text))
        {
            if (HideWhenTextNullOrEmpty)
                AssociatedObject.IsVisible = false;
            return;
        }

        // Force a measure to get the desired size
        AssociatedObject.IsVisible = true;
        AssociatedObject.Measure(Size.Infinity);

        var desiredSize = AssociatedObject.DesiredSize;
        var actualSize = AssociatedObject.Bounds.Size;

        // Check if the control has been allocated space yet
        if (actualSize.Width <= 0 || actualSize.Height <= 0)
        {
            return;
        }

        // Hide if content doesn't fit within available space
        var hasEnoughWidth = desiredSize.Width <= actualSize.Width + 1.5; // Small tolerance for rounding
        var hasEnoughHeight = desiredSize.Height <= actualSize.Height + 0.5;

        AssociatedObject.IsVisible = hasEnoughWidth && hasEnoughHeight;
    }
}