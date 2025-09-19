using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using AvaloniaGraphControl;
using GrandArchive.Helpers;
using GrandArchive.Helpers.MarkupExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive.Views;

public partial class ComponentDiagramView : UserControl
{
    public ComponentDiagramView()
    {
        InitializeComponent();
    }

    public Array LayoutMethods => new EnumerationExtension(typeof(GraphPanel.LayoutMethods)).ProvideValue(null);

    public static EnumBrushConverter ComponentTypeEnumBrushConverter => new EnumBrushConverter()
    {
        Brushes = new Dictionary<string, Brush>()
        {
            { "Module", new SolidColorBrush(Color.Parse("#ff1d1d1d")) }, // dark gray
            { "Component", new SolidColorBrush(Color.Parse("#ffa5a5a5")) }, // gray
            { "Basic", new SolidColorBrush(Color.Parse("#ffffffff")) }, // white

            { "Construction", new SolidColorBrush(Color.Parse("#ff6600")) },
            { "Structural", new SolidColorBrush(Color.Parse("#ffad4800")) }, // brown
            { "Undefined", new SolidColorBrush(Color.Parse("#ff8f0000")) }, // crimson
            { "Consumable", new SolidColorBrush(Color.Parse("#ffffe5a0")) }, // yellow
            { "Essential", new SolidColorBrush(Color.Parse("#ff11734b")) }, // green
            { "Power", new SolidColorBrush(Color.Parse("#ff0a53a8")) }, // blue
            { "Raw", new SolidColorBrush(Color.Parse("#ff811c8e")) }, // purple
        }
    };

    private async void ExportImage_OnClick(object sender, RoutedEventArgs e)
    {
        // Pick a file to save
        var top = TopLevel.GetTopLevel(GraphPanel);
        var storage = top?.StorageProvider;
        var file = storage is null
            ? null
            : await storage.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "Save graph as image",
                DefaultExtension = "png",
                ShowOverwritePrompt = true,
                FileTypeChoices =
                [
                    new FilePickerFileType("PNG"){ Patterns = ["*.png"] },
                    new FilePickerFileType("JPEG"){ Patterns = ["*.jpg","*.jpeg"] }
                ]
            });

        if (file is null) return;

        Size desired;
        var scale = 1.0;

        // First try unconstrained measure to let it grow to needed size
        GraphPanel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        desired = GraphPanel.DesiredSize;

        // Defensive fallback if the control reports 0 (some panels do until arranged)
        if (desired.Width <= 0 || desired.Height <= 0)
        {
            // Try a generous provisional size, it will clamp to content during Arrange if implemented
            desired = new Size(
                Math.Max(GraphPanel.Bounds.Width,  1024),
                Math.Max(GraphPanel.Bounds.Height, 1024));
        }

        // Arrange to its desired size (this triggers layout of the whole graph)
        GraphPanel.Arrange(new Rect(desired));

        // Give Avalonia a moment to run templates/layout all the way to Render priority
        // (helps with async/queued layout in complex controls)
        await Dispatcher.UIThread.InvokeAsync(() => { }, DispatcherPriority.Render);

        // Re-query final size after arrange
        var finalSize = GraphPanel.Bounds.Size;
        if (finalSize.Width <= 0 || finalSize.Height <= 0)
            return;

        var widthPx  = (int)Math.Ceiling(finalSize.Width  * scale);
        var heightPx = (int)Math.Ceiling(finalSize.Height * scale);

        // Safety cap: enormous graphs can create huge bitmaps
        const int MaxPixels = 16384; // adjust to your needs
        widthPx  = Math.Min(widthPx,  MaxPixels);
        heightPx = Math.Min(heightPx, MaxPixels);

        using var rtb = new RenderTargetBitmap(new PixelSize(widthPx, heightPx),
            new Vector(96 * scale, 96 * scale));

        // Render the *visible* contents of the GraphPanel
        rtb.Render(GraphPanel);

        // Save (format inferred from extension)
        rtb.Save(file.Path.LocalPath);
    }
}