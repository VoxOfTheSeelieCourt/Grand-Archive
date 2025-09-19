using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models;

namespace GrandArchive.Helpers;

public class SpellSchoolToBrushConverter : IValueConverter
{
    public bool AllowMulticolor { get; set; } = true;
    public SolidColorBrush NoneBackground { get; set; }
    public SolidColorBrush AbjurationBackground { get; set; }
    public SolidColorBrush ConjurationBackground { get; set; }
    public SolidColorBrush DivinationBackground { get; set; }
    public SolidColorBrush EnchantmentBackground { get; set; }
    public SolidColorBrush EvocationBackground { get; set; }
    public SolidColorBrush IllusionBackground { get; set; }
    public SolidColorBrush NecromancyBackground { get; set; }
    public SolidColorBrush TransmutationBackground { get; set; }
    public SolidColorBrush UniversalBackground { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not SpellSchool spellSchool)
            return null;

        var brushes = spellSchool.GetFlags()
            .Cast<SpellSchool>()
            .Take(AllowMulticolor ? int.MaxValue : 1)
            .Select(item => item switch
            {
                SpellSchool.None => NoneBackground,
                SpellSchool.Abjuration => AbjurationBackground,
                SpellSchool.Conjuration => ConjurationBackground,
                SpellSchool.Divination => DivinationBackground,
                SpellSchool.Enchantment => EnchantmentBackground,
                SpellSchool.Evocation => EvocationBackground,
                SpellSchool.Illusion => IllusionBackground,
                SpellSchool.Necromancy => NecromancyBackground,
                SpellSchool.Transmutation => TransmutationBackground,
                SpellSchool.Universal => UniversalBackground,
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
        
        brush.GradientStops.AddRange(brushes.Select(x => new GradientStop(x.Color, 1 / (brushes.Count * 2) * (brushes.IndexOf(x) * 2 + 1))));
        return brush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}