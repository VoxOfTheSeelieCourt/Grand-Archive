using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models.Database;

namespace GrandArchive.Helpers.Converter;

public class SpellSchoolToBrushConverter : IValueConverter
{
    public bool AllowMulticolor { get; set; } = true;
    public bool IsReversed { get; set; }
    public ISolidColorBrush NoneBackground { get; set; }
    public ISolidColorBrush AbjurationBackground { get; set; }
    public ISolidColorBrush ConjurationBackground { get; set; }
    public ISolidColorBrush DivinationBackground { get; set; }
    public ISolidColorBrush EnchantmentBackground { get; set; }
    public ISolidColorBrush EvocationBackground { get; set; }
    public ISolidColorBrush IllusionBackground { get; set; }
    public ISolidColorBrush NecromancyBackground { get; set; }
    public ISolidColorBrush TransmutationBackground { get; set; }
    public ISolidColorBrush UniversalBackground { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not DndSpellSchool spellSchool)
            return null;

        var flags = spellSchool.GetFlags()
            .Cast<DndSpellSchool>()
            .ToList();

        if (flags.Count > 1)
            flags.RemoveAll(x => x == DndSpellSchool.None);

        var brushes = flags.Take(AllowMulticolor ? int.MaxValue : 1)
            .Select(item => item switch
            {
                DndSpellSchool.None => NoneBackground,
                DndSpellSchool.Abjuration => AbjurationBackground,
                DndSpellSchool.Conjuration => ConjurationBackground,
                DndSpellSchool.Divination => DivinationBackground,
                DndSpellSchool.Enchantment => EnchantmentBackground,
                DndSpellSchool.Evocation => EvocationBackground,
                DndSpellSchool.Illusion => IllusionBackground,
                DndSpellSchool.Necromancy => NecromancyBackground,
                DndSpellSchool.Transmutation => TransmutationBackground,
                DndSpellSchool.Universal => UniversalBackground,
                _ => throw new ArgumentOutOfRangeException()
            })
            .ToList();

        if (brushes.Count < 2)
            return brushes.FirstOrDefault();
        var brush = new LinearGradientBrush()
        {
            StartPoint = new RelativePoint(0, 0.5, RelativeUnit.Relative),
            EndPoint = new  RelativePoint(1, 0.5, RelativeUnit.Relative)
        };

        if (IsReversed)
            brushes.Reverse();

        brush.GradientStops.AddRange(brushes.Select(x => new GradientStop(x.Color, 1d / (brushes.Count * 2) * (brushes.IndexOf(x) * 2 + 1))));
        return brush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}