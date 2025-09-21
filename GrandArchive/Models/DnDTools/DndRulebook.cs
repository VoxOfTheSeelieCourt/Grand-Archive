using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndRulebook
{
    public int Id { get; set; }

    public int DndEditionId { get; set; }

    public string Name { get; set; }

    public string Abbr { get; set; }

    public string Description { get; set; }

    public string Year { get; set; }

    public string OfficialUrl { get; set; }

    public string Slug { get; set; }

    public string Image { get; set; }

    public DateOnly? Published { get; set; }

    public virtual ICollection<DndCharacterclassvariant> DndCharacterclassvariants { get; set; } = new List<DndCharacterclassvariant>();

    public virtual ICollection<DndDomainvariant> DndDomainvariants { get; set; } = new List<DndDomainvariant>();

    public virtual DndDndedition DndEdition { get; set; }

    public virtual ICollection<DndFeat> DndFeats { get; set; } = new List<DndFeat>();

    public virtual ICollection<DndItem> DndItems { get; set; } = new List<DndItem>();

    public virtual ICollection<DndMonster> DndMonsters { get; set; } = new List<DndMonster>();

    public virtual ICollection<DndRace> DndRaces { get; set; } = new List<DndRace>();

    public virtual ICollection<DndRule> DndRules { get; set; } = new List<DndRule>();

    public virtual ICollection<DndSkillvariant> DndSkillvariants { get; set; } = new List<DndSkillvariant>();

    public virtual ICollection<DndSpell> DndSpells { get; set; } = new List<DndSpell>();
}
