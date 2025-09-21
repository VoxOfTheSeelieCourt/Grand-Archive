using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndSkill
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string BaseSkill { get; set; }

    public byte TrainedOnly { get; set; }

    public byte ArmorCheckPenalty { get; set; }

    public string Slug { get; set; }

    public virtual ICollection<DndCharacterclassvariantClassSkill> DndCharacterclassvariantClassSkills { get; set; } = new List<DndCharacterclassvariantClassSkill>();

    public virtual ICollection<DndCharacterclassvariantrequiresskill> DndCharacterclassvariantrequiresskills { get; set; } = new List<DndCharacterclassvariantrequiresskill>();

    public virtual ICollection<DndFeatrequiresskill> DndFeatrequiresskills { get; set; } = new List<DndFeatrequiresskill>();

    public virtual ICollection<DndMonsterhasskill> DndMonsterhasskills { get; set; } = new List<DndMonsterhasskill>();

    public virtual ICollection<DndSkillvariant> DndSkillvariants { get; set; } = new List<DndSkillvariant>();
}
