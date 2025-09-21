using System;
using System.Collections.Generic;

namespace GrandArchive.Models.DnDTools;

public partial class DndMonsterhasfeat
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int FeatId { get; set; }

    public string Extra { get; set; }

    public virtual DndFeat Feat { get; set; }

    public virtual DndMonster Monster { get; set; }
}
