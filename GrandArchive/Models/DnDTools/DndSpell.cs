using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSpell
{
    public int Id { get; set; }

    public DateTime Added { get; set; }

    public int RulebookId { get; set; }

    public short? Page { get; set; }

    public string Name { get; set; }

    public int SchoolId { get; set; }

    public int? SubSchoolId { get; set; }

    public byte VerbalComponent { get; set; }

    public byte SomaticComponent { get; set; }

    public byte MaterialComponent { get; set; }

    public byte ArcaneFocusComponent { get; set; }

    public byte DivineFocusComponent { get; set; }

    public byte XpComponent { get; set; }

    public string CastingTime { get; set; }

    public string Range { get; set; }

    public string Target { get; set; }

    public string Effect { get; set; }

    public string Area { get; set; }

    public string Duration { get; set; }

    public string SavingThrow { get; set; }

    public string SpellResistance { get; set; }

    public string Description { get; set; }

    public string Slug { get; set; }

    public byte MetaBreathComponent { get; set; }

    public byte TrueNameComponent { get; set; }

    public string ExtraComponents { get; set; }

    public string DescriptionHtml { get; set; }

    public byte CorruptComponent { get; set; }

    public short? CorruptLevel { get; set; }

    public byte Verified { get; set; }

    public int? VerifiedAuthorId { get; set; }

    public DateTime? VerifiedTime { get; set; }

    public virtual ICollection<DndItemRequiredSpell> DndItemRequiredSpells { get; set; } = new List<DndItemRequiredSpell>();

    public virtual ICollection<DndSpellDescriptor> DndSpellDescriptors { get; set; } = new List<DndSpellDescriptor>();

    public virtual ICollection<DndSpellclasslevel> DndSpellclasslevels { get; set; } = new List<DndSpellclasslevel>();

    public virtual ICollection<DndSpelldomainlevel> DndSpelldomainlevels { get; set; } = new List<DndSpelldomainlevel>();

    public virtual DndRulebook Rulebook { get; set; }

    public virtual DndSpellschool School { get; set; }

    public virtual DndSpellsubschool SubSchool { get; set; }
}
