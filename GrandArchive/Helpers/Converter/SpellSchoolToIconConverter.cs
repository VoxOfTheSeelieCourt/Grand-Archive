using System;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using Avalonia.Media;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models.Database;

namespace GrandArchive.Helpers.Converter;

public class SpellSchoolToIconConverter : IValueConverter
{
    public bool AllowMultiple { get; set; } = true;
    public Geometry NoneIcon { get; set; }
    public Geometry AbjurationIcon { get; set; }
    public Geometry ConjurationIcon { get; set; }
    public Geometry DivinationIcon { get; set; }
    public Geometry EnchantmentIcon { get; set; }
    public Geometry EvocationIcon { get; set; }
    public Geometry IllusionIcon { get; set; }
    public Geometry NecromancyIcon { get; set; }
    public Geometry TransmutationIcon { get; set; }
    public Geometry UniversalIcon { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not DndSpellSchool spellSchool)
            return null;

        var flags = spellSchool.GetFlags()
            .Cast<DndSpellSchool>()
            .ToList();

        if (flags.Count > 1)
            flags.RemoveAll(x => x == DndSpellSchool.None);

        var icons = flags.Take(AllowMultiple ? int.MaxValue : 1)
            .Select(item => item switch
            {
                DndSpellSchool.None => NoneIcon,
                DndSpellSchool.Abjuration => AbjurationIcon,
                DndSpellSchool.Conjuration => ConjurationIcon,
                DndSpellSchool.Divination => DivinationIcon,
                DndSpellSchool.Enchantment => EnchantmentIcon,
                DndSpellSchool.Evocation => EvocationIcon,
                DndSpellSchool.Illusion => IllusionIcon,
                DndSpellSchool.Necromancy => NecromancyIcon,
                DndSpellSchool.Transmutation => TransmutationIcon,
                DndSpellSchool.Universal => UniversalIcon,
                _ => throw new ArgumentOutOfRangeException()
            })
            .ToList();

        return icons;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}