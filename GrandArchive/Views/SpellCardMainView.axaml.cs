using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using GrandArchive.Models.Database;
using GrandArchive.ViewModels;

namespace GrandArchive.Views;

public partial class SpellCardMainView : UserControl
{
    public SpellCardMainView()
    {
        InitializeComponent();
    }

    private void ExportSelectedSpellCard(object sender, RoutedEventArgs e)
    {
        if (SpellDataGrid.SelectedItem is not DndSpell spell) return;

        Task.Run(() => ExportSpells([spell]));
    }

    private void ExportAllSpellCards(object sender, RoutedEventArgs e)
    {
        var spells = SpellDataGrid.ItemsSource.Cast<DndSpell>().ToList();
        if (!spells.Any()) return;
        
        Task.Run(() => ExportSpells(spells));
    }
    
    private async Task ExportSpells(List<DndSpell> spells)
    {
        var top = TopLevel.GetTopLevel(this);
        var storageProvider = top?.StorageProvider;

        var dir = storageProvider == null
            ? null
            : await storageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
            {
                AllowMultiple = false,
                Title = "Export Spells"
            });

        if (dir == null || dir.Count == 0)
        {
            return;
        }

        Dispatcher.UIThread.Invoke(() =>
        {
            var host = new Canvas { IsHitTestVisible = false, Opacity = 0 };
            var parent = top.Content as Panel ?? throw new InvalidOperationException("No usable panel to attach to.");
            parent.Children.Add(host);

            SpellCardRenderView view = new SpellCardRenderView(){DataContext = spells.First()};
            Canvas.SetLeft(view, -10000000);
            Canvas.SetTop(view, -10000000);
            host.Children.Add(view);

            Dispatcher.UIThread.Invoke(() => { }, DispatcherPriority.Loaded);

            foreach (var spell in spells)
            {
                view.DataContext = spell;

                Dispatcher.UIThread.Invoke(() => { }, DispatcherPriority.Loaded);
                view.InvalidateMeasure();
                view.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                view.Arrange(new Rect(view.DesiredSize));
                Dispatcher.UIThread.Invoke(() => { }, DispatcherPriority.Render);

                SaveControl(view.CutAreaFront, Path.Combine(dir[0].Path.AbsolutePath, $"{spell.Name} Front.png"));
                SaveControl(view.CutAreaBack, Path.Combine(dir[0].Path.AbsolutePath, $"{spell.Name} Back.png"));

                Dispatcher.UIThread.Invoke(() => { }, DispatcherPriority.Background);
            }

            host.Children.Clear();
            parent.Children.Remove(host);
        });
    }

    private static void SaveControl(Control control, string filePath)
    {
        // If a template hasn’t created the visual yet, ensure layout now.
        if (control.Bounds.Width <= 0 || control.Bounds.Height <= 0)
        {
            control.InvalidateMeasure();
            control.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            control.Arrange(new Rect(control.DesiredSize));
            Dispatcher.UIThread.Invoke(() => { }, DispatcherPriority.Render);
        }

        var size = control.Bounds.Size;
        var widthPx  = (int)Math.Ceiling(size.Width);
        var heightPx = (int)Math.Ceiling(size.Height);

        using var rtb = new RenderTargetBitmap(
            new PixelSize(widthPx, heightPx),
            new Vector(96, 96)); // 1 DIP → 1 px @ scaling

        rtb.Render(control);
        rtb.Save(filePath);
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SpellCardMainViewModel vm) return;

        vm.PropertyChanged += (o, args) =>
        {
            if (args.PropertyName == nameof(vm.Spells))
                SpellDataGrid.SelectedItem = vm.Spells.First();
        };

        SpellDataGrid.SelectedItem = vm.Spells.First();
    }
}