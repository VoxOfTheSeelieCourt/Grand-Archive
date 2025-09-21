using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndCharacterclassvariantClassSkill
{
    public int Id { get; set; }

    public int CharacterclassvariantId { get; set; }

    public int SkillId { get; set; }

    public virtual DndCharacterclassvariant Characterclassvariant { get; set; }

    public virtual DndSkill Skill { get; set; }
}
