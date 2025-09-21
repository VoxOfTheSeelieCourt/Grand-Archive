using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndRace
{
    public int Id { get; set; }

    public int RulebookId { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public short? Page { get; set; }

    public short Str { get; set; }

    public short Dex { get; set; }

    public short? Con { get; set; }

    public short Int { get; set; }

    public short Wis { get; set; }

    public short Cha { get; set; }

    public short LevelAdjustment { get; set; }

    public int SizeId { get; set; }

    public short Space { get; set; }

    public short Reach { get; set; }

    public string Combat { get; set; }

    public string Description { get; set; }

    public string RacialTraits { get; set; }

    public string DescriptionHtml { get; set; }

    public string CombatHtml { get; set; }

    public string RacialTraitsHtml { get; set; }

    public short? NaturalArmor { get; set; }

    public string Image { get; set; }

    public int? RaceTypeId { get; set; }

    public short? RacialHitDiceCount { get; set; }

    public virtual ICollection<DndCharacterclassvariantrequiresrace> DndCharacterclassvariantrequiresraces { get; set; } = new List<DndCharacterclassvariantrequiresrace>();

    public virtual ICollection<DndRaceAutomaticLanguage> DndRaceAutomaticLanguages { get; set; } = new List<DndRaceAutomaticLanguage>();

    public virtual ICollection<DndRaceBonusLanguage> DndRaceBonusLanguages { get; set; } = new List<DndRaceBonusLanguage>();

    public virtual ICollection<DndRacefavoredcharacterclass> DndRacefavoredcharacterclasses { get; set; } = new List<DndRacefavoredcharacterclass>();

    public virtual ICollection<DndRacespeed> DndRacespeeds { get; set; } = new List<DndRacespeed>();

    public virtual DndRacetype RaceType { get; set; }

    public virtual DndRulebook Rulebook { get; set; }

    public virtual DndRacesize Size { get; set; }
}
