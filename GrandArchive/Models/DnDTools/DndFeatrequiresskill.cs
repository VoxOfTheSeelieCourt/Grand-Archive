using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndFeatrequiresskill
{
    public int Id { get; set; }

    public int FeatId { get; set; }

    public int SkillId { get; set; }

    public short MinRank { get; set; }

    public string Extra { get; set; }

    public virtual DndFeat Feat { get; set; }

    public virtual DndSkill Skill { get; set; }
}
