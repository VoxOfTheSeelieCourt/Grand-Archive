using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Interactivity;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models;
using Svg;

namespace GrandArchive.Controls;

public class FlagEnumComboBox : TemplatedControl
{
    private ListBox _listBox;
    private TextBlock _textBlock;
    private Popup _popup;

    public static readonly StyledProperty<Enum> SelectedValueProperty = AvaloniaProperty.Register<FlagEnumComboBox, Enum>(
        nameof(SelectedValue), defaultValue: BindingMode.TwoWay);

    public static readonly StyledProperty<Type> EnumTypeProperty = AvaloniaProperty.Register<FlagEnumComboBox, Type>(
        nameof(EnumType));

    public Enum SelectedValue
    {
        get => GetValue(SelectedValueProperty);
        set => SetValue(SelectedValueProperty, value);
    }

    public Type EnumType
    {
        get => GetValue(EnumTypeProperty);
        set => SetValue(EnumTypeProperty, value);
    }

    static FlagEnumComboBox()
    {
        EnumTypeProperty.Changed.AddClassHandler<FlagEnumComboBox>((x, e) => x.OnEnumTypeChanged(e));
        SelectedValueProperty.Changed.AddClassHandler<FlagEnumComboBox>((x, e) => x.OnSelectedValueChanged(e));
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _listBox = e.NameScope.Find<ListBox>("PART_ListBox");
        _textBlock = e.NameScope.Find<TextBlock>("PART_DisplayTextBlock");
        _popup = e.NameScope.Find<Popup>("PART_Popup");

        if (e.NameScope.Find<Button>("PART_Button") is { } button)
        {
            button.Click += (x, y) => TogglePopup();
        }

        PopulateItems();
        UpdateDisplay();
    }

    private void TogglePopup()
    {
        if (_popup != null)
            _popup.IsOpen = !_popup.IsOpen;
    }

    private void OnEnumTypeChanged(AvaloniaPropertyChangedEventArgs e)
    {
        PopulateItems();
        UpdateDisplay();
    }

    private void OnSelectedValueChanged(AvaloniaPropertyChangedEventArgs e)
    {
        UpdateDisplay();
        UpdateCheckStates();
    }

    private void PopulateItems()
    {
        if (_listBox == null || EnumType is not { IsEnum: true })
            return;

        var items = new List<EnumItem>();
        var values = Enum.GetValues(EnumType);

        foreach (Enum value in values)
        {
            var numericValue = Convert.ToInt64(value);
            if (numericValue == 0 || (numericValue != 1 && numericValue % 2 != 0))
                continue;

            var item = new EnumItem()
            {
                Value = value,
                DisplayName = value.GetDescription()
            };

            items.Add(item);
        }

        _listBox.ItemsSource = items.Select(x =>
        {
            var checkBox = new CheckBox()
            {
                Content = x.DisplayName,
                Tag = x,
                Margin = new Thickness(4, 2)
            };

            checkBox.IsCheckedChanged += CheckBox_IsCheckedChanged;
            return checkBox;
        });

        UpdateCheckStates();
    }


    private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs routedEventArgs)
    {
        if (sender is not CheckBox { Tag: EnumItem })
            return;

        UpdateSelectedValue();
    }

    private void UpdateCheckStates()
    {
        if (_listBox == null || SelectedValue == null || EnumType == null)
            return;

        var selectedLong = Convert.ToInt64(SelectedValue);

        foreach (var control in _listBox.Items.Cast<CheckBox>())
        {
            if (control.Tag is not EnumItem item)
                continue;

            var valueLong = Convert.ToInt64(item.Value);
            var isChecked = (selectedLong & valueLong) == valueLong;

            control.IsCheckedChanged -= CheckBox_IsCheckedChanged;
            control.IsChecked = isChecked;
            control.IsCheckedChanged += CheckBox_IsCheckedChanged;
        }
    }

    private void UpdateSelectedValue()
    {
        if (_listBox == null || EnumType == null)
            return;

        long result = 0;

        foreach (var control in _listBox.Items.Cast<CheckBox>())
        {
            if (control.IsChecked == true && control.Tag is EnumItem flag)
                result |= Convert.ToInt64(flag.Value);
        }

        SelectedValue = (Enum)Enum.ToObject(EnumType, result);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (_textBlock == null || SelectedValue == null)
            return;

        var selectedLong = Convert.ToInt64(SelectedValue);
        if (selectedLong == 0)
        {
            _textBlock.Text = ((Enum)Enum.ToObject(EnumType, 0)).GetDescription();
            return;
        }

        var selected = new List<string>();
        var values = Enum.GetValues(EnumType);

        foreach (Enum value in values)
        {
            var numericValue = Convert.ToInt64(value);
            if (numericValue == 0 || (numericValue != 1 && numericValue % 2 != 0) || (selectedLong & numericValue) != numericValue)
                continue;

            selected.Add(value.GetDescription());
        }

        _textBlock.Text = string.Join(", ", selected);
    }
}