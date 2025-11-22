using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.VisualTree;
using GrandArchive.Models.Database;

namespace GrandArchive.Helpers;

public static class DataGridFilterBehavior
{
    // Turn behavior on/off
    public static readonly AttachedProperty<bool> IsEnabledProperty =
        AvaloniaProperty.RegisterAttached<DataGrid, bool>(
            "IsEnabled", typeof(DataGridFilterBehavior));

    // Per-column filter text (bound by header TextBox)
    public static readonly AttachedProperty<string> FilterTextProperty =
        AvaloniaProperty.RegisterAttached<DataGridColumn, string>(
            "FilterText", typeof(DataGridFilterBehavior));

    // Optional: case sensitivity toggle at grid-level (default: false)
    public static readonly AttachedProperty<bool> CaseSensitiveProperty =
        AvaloniaProperty.RegisterAttached<DataGrid, bool>(
            "CaseSensitive", typeof(DataGridFilterBehavior));

    private static readonly AttachedProperty<DataGridCollectionView> ViewProperty =
        AvaloniaProperty.RegisterAttached<DataGrid, DataGridCollectionView>(
            "_View", typeof(DataGridFilterBehavior));

    static DataGridFilterBehavior()
    {
        IsEnabledProperty.Changed.AddClassHandler<DataGrid>(OnIsEnabledChanged);
        FilterTextProperty.Changed.AddClassHandler<DataGridColumn>(OnAnyFilterChanged);
        CaseSensitiveProperty.Changed.AddClassHandler<DataGrid>(OnCaseChanged);
    }

    // Public setters/getters for XAML
    public static void SetIsEnabled(DataGrid element, bool value) => element.SetValue(IsEnabledProperty, value);
    public static bool GetIsEnabled(DataGrid element) => element.GetValue(IsEnabledProperty);

    public static void SetFilterText(DataGridColumn element, string value) => element.SetValue(FilterTextProperty, value);
    public static string GetFilterText(DataGridColumn element) => element.GetValue(FilterTextProperty);

    public static void SetCaseSensitive(DataGrid element, bool value) => element.SetValue(CaseSensitiveProperty, value);
    public static bool GetCaseSensitive(DataGrid element) => element.GetValue(CaseSensitiveProperty);

    private static void OnIsEnabledChanged(DataGrid grid, AvaloniaPropertyChangedEventArgs args)
    {
        if (args.NewValue is true)
            Attach(grid);
        else
            Detach(grid);
    }

    private static void OnCaseChanged(DataGrid grid, AvaloniaPropertyChangedEventArgs _)
    {
        Refresh(grid);
    }

    private static void OnAnyFilterChanged(DataGridColumn col, AvaloniaPropertyChangedEventArgs _)
    {
        // Find owning grid and refresh
        var grid = FindOwningGrid(col);
        if (grid is not null && GetIsEnabled(grid))
            EnsureView(grid);
    }

    private static DataGrid FindOwningGrid(DataGridColumn column)
    {
        // Column isn't in the visual tree; use the Columns owner reference.
        // In Avalonia, DataGridColumn has an internal Owner; we can scan open grids.
        // Easiest: walk up from any visible header if needed; here we cache by tag:
        // Fallback approach: find first DataGrid in app whose Columns contains column.
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime dlt)
        {
            foreach (var window in dlt.Windows)
            {
                foreach (var grid in window.GetVisualDescendants().OfType<DataGrid>())
                    if (grid.Columns.Contains(column))
                        return grid;
            }
        }
        return null;
    }

    private static void Attach(DataGrid grid)
    {
        // Rebuild view when:
        // - ItemsSource changes
        // - Columns change
        grid.PropertyChanged += (_, e) =>
        {
            if (e.Property.Name is nameof(ItemsControl.ItemsSource) or nameof(ItemsControl.Items))
                EnsureView(grid);
        };

        grid.Columns.CollectionChanged += (_, __) => Refresh(grid);

        EnsureView(grid);
    }

    private static void Detach(DataGrid grid)
    {
        var view = grid.GetValue(ViewProperty);
        if (view != null)
        {
            // Clear filter to avoid dangling refs
            view.Filter = null;
            grid.ClearValue(ViewProperty);
        }
    }

    private static void EnsureView(DataGrid grid)
    {
        // If it's already a DataGridCollectionView, use it; otherwise wrap it
        var currentItems = grid.CollectionView;

        if (currentItems != null)
        {
            // grid.SetValue(ViewProperty, currentItems);
            // (Re)set our Filter delegate
            currentItems.Filter = o => ApplyAllColumnFilters(grid, o);
        }

        Refresh(grid);
    }

    private static void Refresh(DataGrid grid)
    {
        var view = grid.GetValue(ViewProperty);
        view?.Refresh();
    }

    private static bool ApplyAllColumnFilters(DataGrid grid, object row)
    {
        if (row is null)
            return false;

        var caseSensitive = GetCaseSensitive(grid);
        var comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

        foreach (var col in grid.Columns)
        {
            var needle = GetFilterText(col);
            if (string.IsNullOrWhiteSpace(needle))
                continue;

            // Try to resolve a binding path for bound columns (Text/CheckBox etc.)
            var path = TryGetBindingPath(col);
            if (path is null)
            {
                // Fallback: ToString() match
                var s = row.ToString() ?? string.Empty;
                if (s.IndexOf(needle, comparison) < 0)
                    return false;
                continue;
            }

            var value = ReadPropertyPath(row, path);
            var text = value?.ToString() ?? string.Empty;

            if (text.IndexOf(needle, comparison) < 0)
                return false;
        }

        return true;
    }

    private static string TryGetBindingPath(DataGridColumn column)
    {
        // Works for DataGridTextColumn and other bound columns
        if (column is DataGridBoundColumn bound && bound.Binding is CompiledBindingExtension b && !string.IsNullOrWhiteSpace(b.Path.ToString()))
            return b.Path.ToString();

        return null;
    }

    private static object ReadPropertyPath(object instance, string path)
    {
        var current = instance;
        foreach (var seg in path.Split('.'))
        {
            if (current is null) return null;
            var t = current.GetType();
            var prop = t.GetProperty(seg, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (prop == null) return null;
            current = prop.GetValue(current);
        }
        return current;
    }

    // Helper to enumerate visuals (since we used it above)
    private static IEnumerable<Visual> GetVisualDescendants(this Visual root)
    {
        if (root is null) yield break;
        var stack = new Stack<Visual>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var v = stack.Pop();
            foreach (var child in v.GetVisualChildren())
            {
                yield return child;
                stack.Push(child);
            }
        }
    }
}