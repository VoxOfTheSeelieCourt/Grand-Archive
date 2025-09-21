using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndMonster
{
    public int Id { get; set; }

    public int RulebookId { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public short? Page { get; set; }

    public int? SizeId { get; set; }

    public int TypeId { get; set; }

    public string HitDice { get; set; }

    public short Initiative { get; set; }

    public string ArmorClass { get; set; }

    public short? TouchArmorClass { get; set; }

    public short? FlatFootedArmorClass { get; set; }

    public short BaseAttack { get; set; }

    public short Grapple { get; set; }

    public string Attack { get; set; }

    public string FullAttack { get; set; }

    public short Space { get; set; }

    public short Reach { get; set; }

    public string SpecialAttacks { get; set; }

    public string SpecialQualities { get; set; }

    public short FortSave { get; set; }

    public string FortSaveExtra { get; set; }

    public short ReflexSave { get; set; }

    public string ReflexSaveExtra { get; set; }

    public short WillSave { get; set; }

    public string WillSaveExtra { get; set; }

    public short Str { get; set; }

    public short Dex { get; set; }

    public short? Con { get; set; }

    public short Int { get; set; }

    public short Wis { get; set; }

    public short Cha { get; set; }

    public string Environment { get; set; }

    public string Organization { get; set; }

    public short ChallengeRating { get; set; }

    public string Treasure { get; set; }

    public string Alignment { get; set; }

    public string Advancement { get; set; }

    public short? LevelAdjustment { get; set; }

    public string Description { get; set; }

    public string DescriptionHtml { get; set; }

    public string Combat { get; set; }

    public string CombatHtml { get; set; }

    public virtual ICollection<DndMonsterSubtype> DndMonsterSubtypes { get; set; } = new List<DndMonsterSubtype>();

    public virtual ICollection<DndMonsterhasfeat> DndMonsterhasfeats { get; set; } = new List<DndMonsterhasfeat>();

    public virtual ICollection<DndMonsterhasskill> DndMonsterhasskills { get; set; } = new List<DndMonsterhasskill>();

    public virtual ICollection<DndMonsterspeed> DndMonsterspeeds { get; set; } = new List<DndMonsterspeed>();

    public virtual DndRulebook Rulebook { get; set; }

    public virtual DndRacesize Size { get; set; }

    public virtual DndMonstertype Type { get; set; }
}
