using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndMonsterhasskill
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int SkillId { get; set; }

    public short Ranks { get; set; }

    public string Extra { get; set; }

    public virtual DndMonster Monster { get; set; }

    public virtual DndSkill Skill { get; set; }
}
